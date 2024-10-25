// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("cBvCtiJdpvkZh/GIjel3Tj0Qv/yetB/GXgxJzYncVMHIUMchgNcCcYGNzpNxugUG930c1Z40ZRUZ0M57nCT1onTmj1wd3z7Hz+1kBYS1mAmDPrE0Y7m8glY2g5dRAb/CzmUwYdstQw2Oo7Jix3nQWe85fQ4xGeyWnl4mJSwy3eW9DuHQNf4Z0SxYRsKsws3NPfPieXd61sMCHpC5xPyxnYiDbgnyfp7o1LNbxb7WV2XR/kd2VEw0nsskF6C+GuTgoyfsOsqMOfEOAzyZQwG3NCHPUuk6pccDN6iiYJREvA7zfdK0NuHg4DmBva0OAjkgSvh7WEp3fHNQ/DL8jXd7e3t/enn4e3V6Svh7cHj4e3t66Uo8erS5+zp6oDEL7ks+8Xh5e3p7");
        private static int[] order = new int[] { 6,8,9,9,10,10,11,9,12,13,10,13,13,13,14 };
        private static int key = 122;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
