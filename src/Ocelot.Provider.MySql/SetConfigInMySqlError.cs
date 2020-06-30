namespace Ocelot.Provider.MySql
{
    using Ocelot.Errors;
    public class SetConfigInMySqlError : Error
    {
        public SetConfigInMySqlError(string s, int code)
            : base(s, OcelotErrorCode.UnknownError, code)
        {
        }
    }
}
