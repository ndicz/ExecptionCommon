using System;
using System.Collections.Generic;
using System.Text;

namespace ExecptionCommon
{
    public interface ICustomer
    {
        IAsyncEnumerable<CustomerStreamDto> GetCustomersList(GetCustomersParameterDTO poParameter);
        CustomerResultDto GetCustomerByTd(GetCustomerByIdParameterDTO poParameter);
    }
}
