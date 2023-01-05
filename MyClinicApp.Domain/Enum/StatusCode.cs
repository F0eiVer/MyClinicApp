using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,
        IternalServerError = 500,
        DoesNotFind = 405,
        DoesNotSetLogin = 406,
        DoesNotSetPassword = 407,
        DoesNotHaveImpl = 408,
        DoesNotSetUser = 409

    }
}
