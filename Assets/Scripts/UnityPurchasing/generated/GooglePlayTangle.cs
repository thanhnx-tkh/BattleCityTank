// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("pM8WYvaJci3NUyVcWT2jmunEaygP+ZfZWndmthOtBI077ana5c04QngWGRnpJzato64CF9bKRG0QKGVJQJBo2iepBmDiNTQ07VVpedrW7fRKivLx+OYJMWnaNQThKs0F+IySFlfqZeC3bWhWguJXQ4XVaxYaseS1gJjgSh/ww3RqzjA0d/M47h5Y7SWeLK+MnqOop4Qo5ihZo6+vr6uurVVZGkelbtHSI6nIAUrgscHNBBqvLK+hrp4sr6SsLK+vrj2e6K5gbS9I8CF2oDJbiMkL6hMbObDRUGFM3drX6E2X1WPg9RuGPe5xE9fjfHa0SmDLEorYnRldCIAVHIQT9VQD1qVcV7rdJqpKPABnjxFqAoOxBSqTou6udOXfOp/qJaytr66v");
        private static int[] order = new int[] { 6,4,3,7,11,10,13,13,9,11,13,13,13,13,14 };
        private static int key = 174;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
