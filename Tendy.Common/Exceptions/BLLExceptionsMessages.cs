using Tendy.Common.Utils;

namespace Tendy.Common.Exceptions
{
    public static class BLLExceptionsMessages
    {
        //Idea
        public static readonly ErrorInfo CantFindIdea =   new ErrorInfo("01x00001", "Can not find an Idea!");
        public static readonly ErrorInfo CantCreateIdea = new ErrorInfo("01x00002", "Can not create an Idea!");
        public static readonly ErrorInfo CantEditeIdea =  new ErrorInfo("01x00003", "Can not edite an Idea!");
        public static readonly ErrorInfo CantDeleteIdea = new ErrorInfo("01x00004", "Can not delete an Idea!");

        //Accounts
        public static readonly ErrorInfo CantRegisterAccount = new ErrorInfo("02x00001", "Can not register an account!");
        public static readonly ErrorInfo CantAssignUserRole = new ErrorInfo("02x00002", "Can not assign user role!");
	}
}