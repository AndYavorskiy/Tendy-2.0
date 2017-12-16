using Tendy.Common.Utils;

namespace Tendy.Common.Exceptions
{
    public static class BLLExceptionsMessages
    {
        /// <summary>
        /// "01"- errors category | "00" - NOT, "01" - YES | 201 - code
        /// </summary>

        //Idea
        public static readonly ErrorInfo CantFindIdea = new ErrorInfo("01x01404", "Can not find an Idea!");
        public static readonly ErrorInfo CantCreateIdea = new ErrorInfo("01x00201", "Can not create an Idea!");
        public static readonly ErrorInfo CantEditeIdea = new ErrorInfo("01x00201", "Can not edite an Idea!");
        public static readonly ErrorInfo CantDeleteIdea = new ErrorInfo("01x00500", "Can not delete an Idea!");
    }
}
