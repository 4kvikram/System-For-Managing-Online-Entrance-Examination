using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEntranceRegistration.Static
{
    public class Constant
    {

    }
    public static class statusConstant
    {
        public const int Active = 1;
        public const int DeActive = 0;
        public const int Delete = 2;
    }
    public static class RoleConstant
    {
        public const int Applicant = 1;
        public const int Admin = 2;
    }
    public static class SessionConstant
    {
        public const int Id = 0;
        public const int Name = 1;
        public const int Email = 2;
        public const int Role = 3;

    }
    public static class GenderConstant
    {
        public const int Male= 1;
        public const int Female= 2;
        public const int Other = 3;
    }
    public static class ApplicationStatusConstant
    {
        public const int Application_Available = 1;
        public const int Application_Closed = 2;
        public const int Application_Will_Available = 3;
    }
}