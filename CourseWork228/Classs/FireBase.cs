using FireSharp.Config;
using FireSharp.Interfaces;

namespace CourseWorkProgram.Classes
{
    internal class FireBase
    {
        protected const string BaseSecret = "SfqcJcoOhrd2eFk5bYEX2owy6Q1sxrVPIIDV5YBg";
        protected const string Path = "https://coursework-b33d2-default-rtdb.firebaseio.com/";
        public IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = BaseSecret,
            BasePath = Path
        };
        public IFirebaseClient client;
    }
}
