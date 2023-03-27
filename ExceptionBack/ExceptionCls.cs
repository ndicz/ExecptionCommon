using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecptionCommon;
using R_Common;

namespace ExceptionBack
{
    public class ExceptionCls
    {
        public List<CustomerStreamDto> GetCustomersDb(GetCustomersDbParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            List<CustomerStreamDto> loRtn = null;
            try
            {
                //simulasi Error kalau count>50
                if (poParameter.CustomerCount > 50)
                {
                    loException.Add("01", "Error Count>50");
                    goto EndBlock;
                }

                loRtn = new List<CustomerStreamDto>();
                for (int lnCount = 1; lnCount <= poParameter.CustomerCount; lnCount++)
                {
                    loRtn.Add(new CustomerStreamDto()
                        {
                            CustomerId = String.Format("C-{0}", lnCount.ToString()),
                            CustomerName = String.Format("Customer {0}", lnCount.ToString())
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
            EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }




        public CustomerDto GetCustomerByIdDb(GetCustomerByIdDbParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            CustomerDto loRtn = null;
            try
            {
                loRtn = new CustomerDto()
                {
                    CustomerId = String.Format("C-{0}", poParameter.CustomerId),
                    CustomerName = String.Format("Customer {0}", poParameter.CustomerId),
                    DateOfBirth = DateTime.Now.ToString("yyyyMMdd")
                };
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
