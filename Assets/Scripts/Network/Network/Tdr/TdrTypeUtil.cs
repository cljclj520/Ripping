/* This file is generated by tdr. */
/* No manual modification is permitted. */

/* creation time: Tue Feb 10 15:13:53 2015 */
/* tdr version: 2.7.3, build at 20141126 */


using System;
using System.Net;
using System.Diagnostics;
using System.Globalization;

namespace tsf4g_tdr_csharp
{

public class TdrTypeUtil
{

    public static Int32 cstrlen(byte[] str)
    {
        byte nullChar = 0x00;
        Int32 count = 0;
        for(int i =0;i < str.GetLength(0); i++)
        {
            if(nullChar == str[i])
            {
                break;
            }

            count++;
        }

        return count;
    }

    public static Int32 wstrlen(Int16[] str)
    {
        Int16 nullChar = 0x0000;
        Int32 count = 0;
        for(int i =0;i < str.GetLength(0); i++)
        {
            if(nullChar == str[i])
            {
                break;
            }

            count++;
        }

        return count;
    }

    public static TdrError.ErrorType str2TdrIP(out UInt32 ip,string strip)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        IPAddress address;
        byte[] szIP;
        if(IPAddress.TryParse(strip, out address))
        {
            szIP = address.GetAddressBytes();
            ip = (uint)((szIP[3] << 24) | (szIP[2] << 16) | (szIP[1] << 8) | szIP[0]);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            ip = 0;
            ret =  TdrError.ErrorType.TDR_ERR_INVALID_TDRIP_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType tdrIP2Str(ref TdrVisualBuf buf,UInt32 ip)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        IPAddress address = new IPAddress((Int64)ip);
        string strip = address.ToString();

        ret = buf.sprintf("{0}", strip);

        return ret;
    }

    public static TdrError.ErrorType str2TdrTime(out UInt32 time,string strTime)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        DateTime dt;
        TdrTime tdrTime = new TdrTime();

        if (DateTime.TryParse(strTime, out dt))
        {
            tdrTime.nHour = (short)dt.TimeOfDay.Hours;
            tdrTime.bMin = (byte)dt.TimeOfDay.Minutes;
            tdrTime.bSec = (byte)dt.TimeOfDay.Seconds;

            tdrTime.toTime(out time);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            time = 0;
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType tdrTime2Str(ref TdrVisualBuf buf, UInt32 time)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        TdrTime tm = new TdrTime();

        ret = tm.parse(time);
        if(TdrError.ErrorType.TDR_NO_ERROR == ret)
        {
            ret = buf.sprintf("{0:d2}:{1:d2}:{2:d2}", tm.nHour, tm.bMin , tm.bSec);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRTIME_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType str2TdrDate(out UInt32 date,string strDate)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        DateTime dt;
        TdrDate tdrDate = new TdrDate();

        if (DateTime.TryParse(strDate, out dt))
        {
            tdrDate.nYear = (short)dt.Year;
            tdrDate.bMon = (byte)dt.Month;
            tdrDate.bDay = (byte)dt.Day;

            tdrDate.toDate(out date);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            date = 0;
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATE_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType tdrDate2Str(ref TdrVisualBuf buf, UInt32 date)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        TdrDate tdrDate = new TdrDate();

        ret = tdrDate.parse(date);
        if(TdrError.ErrorType.TDR_NO_ERROR == ret)
        {
            ret = buf.sprintf("{0:d4}-{1:d2}-{2:d2}", tdrDate.nYear, tdrDate.bMon ,tdrDate.bDay);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATE_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType str2TdrDateTime(out UInt64 datetime,string strDateTime)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        DateTime dt;
        TdrDateTime tdrDateTime = new TdrDateTime();

        if (DateTime.TryParse(strDateTime, out dt))
        {
            tdrDateTime.tdrDate.nYear = (short)dt.Year;
            tdrDateTime.tdrDate.bMon = (byte)dt.Month;
            tdrDateTime.tdrDate.bDay = (byte)dt.Day;

            tdrDateTime.tdrTime.nHour = (short)dt.TimeOfDay.Hours;
            tdrDateTime.tdrTime.bMin = (byte)dt.TimeOfDay.Minutes;
            tdrDateTime.tdrTime.bSec = (byte)dt.TimeOfDay.Seconds;

            tdrDateTime.toDateTime(out datetime);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            datetime = 0;
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATETIME_VALUE;
        }

        return ret;
    }

    public static TdrError.ErrorType tdrDateTime2Str(ref TdrVisualBuf buf, UInt64 datetime)
    {
        TdrError.ErrorType ret = TdrError.ErrorType.TDR_NO_ERROR;
        TdrDateTime tdrDateTime = new TdrDateTime();

        ret = tdrDateTime.parse(datetime);
        if(TdrError.ErrorType.TDR_NO_ERROR == ret)
        {
            ret = buf.sprintf("{0:d4}-{1:d2}-{2:d2} {3:d2}:{4:d2}:{5:d2}",
                    tdrDateTime.tdrDate.nYear, tdrDateTime.tdrDate.bMon ,tdrDateTime.tdrDate.bDay,
                    tdrDateTime.tdrTime.nHour, tdrDateTime.tdrTime.bMin, tdrDateTime.tdrTime.bSec);
        }
        else
        {
#if (DEBUG)
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                if (null != st.GetFrame(i).GetFileName())
                {
                    Console.WriteLine(st.GetFrame(i).ToString());
                }
            }
#endif
            ret = TdrError.ErrorType.TDR_ERR_INVALID_TDRDATETIME_VALUE;
        }

        return ret;
    }

}


}
