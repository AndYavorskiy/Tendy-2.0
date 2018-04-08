using Tendy.Common.Utils;

namespace Tendy.Common.Exceptions
{
    public static class ExceptionsMessages
    {
        //Idea
        public static readonly ErrorInfo CantFindIdea =   new ErrorInfo("01x00001", "Can not find an Idea!");
        public static readonly ErrorInfo CantCreateIdea = new ErrorInfo("01x00002", "Can not create an Idea!");
        public static readonly ErrorInfo CantEditeIdea =  new ErrorInfo("01x00003", "Can not edite an Idea!");
        public static readonly ErrorInfo CantDeleteIdea = new ErrorInfo("01x00004", "Can not delete an Idea!");

        //Accounts
        public static readonly ErrorInfo CantRegisterAccount = new ErrorInfo("02x00001", "Can not register an account!");
        public static readonly ErrorInfo CantAssignUserRole = new ErrorInfo("02x00002", "Can not assign user role!");

		//Attachments
		//--Links
		public static readonly ErrorInfo CantFindLinks = new ErrorInfo("03x00001", "Can not find Links!");
		public static readonly ErrorInfo CantUpdateLinks = new ErrorInfo("03x00003", "Can not update Links!");
		//--Files
		public static readonly ErrorInfo CantFindFiles = new ErrorInfo("04x00001", "Can not find Files!");
		public static readonly ErrorInfo CantUpdateFiles = new ErrorInfo("04x00003", "Can not update Files!");

		//Account Configuration
		public static readonly ErrorInfo CantUpdateAccountConfiguration = new ErrorInfo("05x00003", "Can not update Account Configuration!");

		//Requsts
		public static readonly ErrorInfo CannotAcceptDeclaimRequest = new ErrorInfo("06x00003", "Can not Accept/Declaim Request!");
	}
}