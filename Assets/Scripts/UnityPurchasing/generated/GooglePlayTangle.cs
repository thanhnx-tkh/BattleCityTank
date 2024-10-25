// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("OYQLjtkDBjjsjDkt67sFeHTfitthl/m3NBkI2H3DauNVg8e0i6NWLCQOpXzktvN3M2bue3LqfZs6bbjLJOScn5aIZ18HtFtqj0Sja5bi/HgWeHd3h0lYw83AbHm4pCoDfkYLJ/BCweLwzcbJ6kaIRjfNwcHBxcDDJp5PGM5cNeanZYR9dVfevz4PIrO0uYYj+bsNjpt16FOAH325jRIY2js3dCnLAL+8TcembySO36+janTByqF4DJjnHEOjPUsyN1PN9IeqBUYyOdSzSMQkUm4J4X8EbO3fa0T9zELBz8DwQsHKwkLBwcBT8IbADgNB7vaOJHGerRoEoF5aGZ1WgHA2g0su/ga0ScdoDoxbWlqDOwcXtLiDmoDAGouxVPGES8LDwcDB");
        private static int[] order = new int[] { 10,4,8,11,11,10,8,10,9,9,12,11,13,13,14 };
        private static int key = 192;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
