using System.Threading;

namespace SeleniumTest_MeetUp
{
    internal static class Helpers
    {
        public static void Pause(int secondsToPause = 3000)
        {
            Thread.Sleep(secondsToPause);
        }
    }
}
