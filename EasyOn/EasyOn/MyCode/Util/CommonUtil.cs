using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyOn {
    public class CommonUtil {

        // java Timestamp.getTime() / 1000 => C# DateTime 변환
        public static DateTime javaTimeStampToDateTime(int javaTimeStamp) {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(javaTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
}
