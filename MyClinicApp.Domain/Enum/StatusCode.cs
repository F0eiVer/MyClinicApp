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
        DoesNotSetSpecialization = 408,
        DoesNotSetTimetable = 409,
        DoesNotSetAppointment = 410,
        DoesNotHaveImpl = 411,
        DoesNotSetUser = 412,
        DoesNotSetDoctor = 413,
    }
}
