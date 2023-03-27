using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_Common;
using R_CommonFrontBackAPI;
using Microsoft.AspNetCore.Mvc;
using ExecptionCommon;
using ExceptionBack;

namespace ExceptionService
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExceptionController : ControllerBase, ICustomer
    {
        [HttpPost]
        public async IAsyncEnumerable<CustomerStreamDto> GetCustomersList(GetCustomersParameterDto poParameter)
        {
            List<CustomerStreamDto> loRtnTemp;
            ExceptionCls loCls = null;
            GetCustomersDbParameterDTO loParameter;

            //Siapkan data CLs
            loCls = new ExceptionCls();
            //siapkan parameter back
            loParameter = new GetCustomersDbParameterDTO() { CustomerCount = poParameter.CustomerCount };
            loRtnTemp = loCls.GetCustomersDb(loParameter);
            foreach (CustomerStreamDto loEntity in loRtnTemp)
            {
                yield return loEntity;
                await Task.Delay(50);
            }
        }


        [HttpPost]
        public CustomerResultDto GetCustomerByTd(GetCustomerByIdParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            CustomerResultDto loRtn = null;
            ExceptionCls loCls = null;
            try
            {
                loRtn = new CustomerResultDto();
                loCls = new ExceptionCls();
                loRtn.data = loCls.GetCustomerByIdDb(new GetCustomerByIdDbParameterDTO() { CustomerId = poParameter.CustomerId });

            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}
