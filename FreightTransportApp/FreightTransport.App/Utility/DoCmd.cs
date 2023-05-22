using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace FreightTransport.App.Utility
{

  public enum TypeReturnNullToValue
  {
    ReturnString = 1,
    ReturnNumeric = 2,
    ReturnBoolean = 3,
    ReturnDate = 4
  }

  public enum UpDown
  {
    Up = 1,
    Down = 2
  }

  public enum DateFormat
  {
    NotZero = 0,
    Day_Month_Year = 1,
    Day_MonthName_Year = 2,
    DayName_MonthName_Year = 3,
    Day_Month_YearTwoDigits = 4
  }

  public enum TimeFormat
  {
    HourComplete_Minute = 1,
    Hour_Minute = 2,
    HourComplete_Minute_AMPM = 3,
    Hour_Minute_AMPM = 4,
    HourComplete_Minute_Second = 5,
    Hour_Minute_Second = 6,
    HourComplete_Minute_Second_AMPM = 7,
    Hour_Minute_Second_AMPM = 8
  }

  public enum CompareMethod
  {
    Binary = 0,
    Text = 1
  }

  public class DoCmd
  {

    public class DBNull
    {

      public static object ReturnDBNullToValue(object value, TypeReturnNullToValue type)
      {
        object Retorno = new object();
        switch (type)
        {
          case TypeReturnNullToValue.ReturnString:
            if (value == null) { Retorno = string.Empty; }
            else { Retorno = value; }
            break;
          case TypeReturnNullToValue.ReturnNumeric:
            if (value == null) { Retorno = 0; }
            else { Retorno = value; }
            break;
          case TypeReturnNullToValue.ReturnDate:
            if (value == null) { Retorno = DateTime.MinValue; }
            else { Retorno = value; }
            break;
          case TypeReturnNullToValue.ReturnBoolean:
            if (value == null) { Retorno = false; }
            else { Retorno = value; }
            break;
        }
        return Retorno;
      }

      public static string DBNullString(object value)
      { return (value == null) ? string.Empty : value.ToString(); }

      public static int DBNullInteger(object value)
      { return (value == null) ? 0 : (int)value; }

      public static long DBNullLong(object value)
      { return (value == null) ? 0 : (long)value; }

      public static double DBNullDouble(object value)
      { return (value == null) ? 0 : (double)value; }

      public static bool DBNullBoolean(object value)
      { return (value == null) ? false : (bool)value; }

      public static DateTime DBNullDate(object value)
      { return (value == null) ? DateTime.MinValue : (DateTime)value; }

    }

    public class DateAndTime
    {
      public static string GetMinDateString()
      { return "01/01/1900 12:00 am"; }

      public static System.DateTime GetDateBD(SqlConnection cnx)
      {
        string SQL;
        SqlDataReader rd;
        System.DateTime dReturn = System.DateTime.Now;
        if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
        SQL = "Select GetDate() Fecha";
        SqlCommand cmd;
        cmd = cnx.CreateCommand();
        cmd.CommandText = SQL;
        rd = cmd.ExecuteReader();
        while (rd.Read())
        { dReturn = System.DateTime.Parse(((DateTime)rd.GetValue(0)).ToString("dd/MM/yyyy")); }
        rd.Close();
        return dReturn;
      }

      public static System.DateTime GetTimeBD(SqlConnection cnx)
      {
        string SQL;
        SqlDataReader rd;
        System.DateTime dReturn = System.DateTime.Now;
        if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
        SQL = "Select GetDate() Hora";
        SqlCommand cmd;
        cmd = cnx.CreateCommand();
        cmd.CommandText = SQL;
        rd = cmd.ExecuteReader();
        while (rd.Read())
        { dReturn = System.DateTime.Parse(((DateTime)rd.GetValue(0)).ToString("HH:mm tt")); }
        rd.Close();
        return dReturn;
      }

      public static System.DateTime GetDateTimeBD(SqlConnection cnx)
      {
        string SQL;
        SqlDataReader rd;
        System.DateTime dReturn = System.DateTime.Now;
        if (cnx.State == ConnectionState.Closed) { cnx.Open(); }
        SQL = "Select GetDate() Fecha";
        SqlCommand cmd;
        cmd = cnx.CreateCommand();
        cmd.CommandText = SQL;
        rd = cmd.ExecuteReader();
        while (rd.Read())
        { dReturn = System.DateTime.Parse(((DateTime)rd.GetValue(0)).ToString("dd/MM/yyyy HH:mm:ss.fff")); }
        rd.Close();
        return dReturn;
      }

      public static bool IsDateBD(string fecha, SqlConnection cnx)
      {
        string SQL;
        SqlDataReader rd;
        bool dReturn = false;
        SQL = "Select IsDate('" + fecha + "') Valor";
        SqlCommand cmd;
        cmd = cnx.CreateCommand();
        cmd.CommandText = SQL;
        rd = cmd.ExecuteReader();
        while (rd.Read())
        { dReturn = bool.Parse(rd.GetValue(0).ToString()); }
        rd.Close();
        return dReturn;
      }

      public static System.DateTime LastDayOfMonth(System.DateTime fdate, SqlConnection cnx)
      {
        string SQL = string.Empty;
        string last = string.Empty;
        System.DateTime DtFechaServ;
        System.DateTime dReturn = System.DateTime.Now;
        DtFechaServ = GetDateBD(cnx);
        if (fdate.Month == DtFechaServ.Month)
        { dReturn = DtFechaServ; }
        else
        {
          last = new System.DateTime(fdate.Year, fdate.Month + 1, 0).Day.ToString();
          dReturn = System.DateTime.Parse(string.Format("00", last) + "/" +
                                          string.Format("00", fdate.Month) + "/" +
                                          string.Format("0000", fdate.Year));
        }
        return dReturn;
      }

      public static System.DateTime FirstDayOfMonth(System.DateTime fdate, SqlConnection cnx)
      {
        System.DateTime dReturn = System.DateTime.Now;
        dReturn = System.DateTime.Parse(string.Format("00", 1) + "/" +
                                        string.Format("00", fdate.Month) + "/" +
                                        string.Format("0000", fdate.Year));
        return dReturn;
      }

      public static int Day(DateTime date) => date.Day;

      public static int Month(DateTime date) => date.Month;

      public static int Year(DateTime date) => date.Year;

      public static string DayStr(DateTime date) => ("00" + date.Day.ToString().Trim()).Right(2);

      public static string MonthStr(DateTime date) => ("00" + date.Month.ToString().Trim()).Right(2);

      public static string YearStr(DateTime date) => ("0000" + date.Year.ToString().Trim()).Right(4);

    }

    public class Strings
    {

      public static string SpaceRight(string valuetext, int valueWidth)
      { return valuetext.PadRight(valueWidth, char.Parse(" ")); }

      public static string SpaceLeft(string valuetext, int valueWidth)
      { return valuetext.PadLeft(valueWidth, char.Parse(" ")); }

      public static string CharacterRepeatRight(string valuetext, char character, int valuewidth)
      { return valuetext.PadRight(valuewidth, character); }

      public static string CharacterRepeatLeft(string valuetext, char character, int valuewidth)
      { return valuetext.PadLeft(valuewidth, character); }

      public static int Asc(char String)
      { return Convert.ToInt32(String); }

      public static int Asc(string String)
      { return Convert.ToInt32(String); }

      public static char Chr(int CharCode)
      { return Convert.ToChar(CharCode); }

      public static char GetChar(string str, int Index)
      { return str.ElementAt(Index); }

      public static int InStr(int Start, string String, string strFind, CompareMethod Compare = 0)
      { return String.IndexOf(strFind, Start); }

      public static int InStr(string String, string strFind, CompareMethod Compare = 0)
      { return String.IndexOf(strFind); }

      public static char LCase(char Value)
      { return Convert.ToChar(Value.ToString().ToLower()); }

      public static string LCase(string Value)
      { return Value.ToLower(); }

      public static char UCase(char Value)
      { return Convert.ToChar(Value.ToString().ToUpper()); }

      public static string UCase(string Value)
      { return Value.ToUpper(); }

      public static int Len(bool Expression)
      { return Expression.ToString().Length; }

      public static int Len(byte Expression)
      { return Expression.ToString().Length; }

      public static int Len(char Expression)
      { return Expression.ToString().Length; }

      public static int Len(decimal Expression)
      { return Expression.ToString().Length; }

      public static int Len(double Expression)
      { return Expression.ToString().Length; }

      public static int Len(float Expression)
      { return Expression.ToString().Length; }

      public static int Len(int Expression)
      { return Expression.ToString().Length; }

      public static int Len(long Expression)
      { return Expression.ToString().Length; }

      public static int Len(object Expression)
      { return Expression.ToString().Length; }

      public static int Len(sbyte Expression)
      { return Expression.ToString().Length; }

      public static int Len(short Expression)
      { return Expression.ToString().Length; }

      public static int Len(string Expression)
      { return Expression.Length; }

      public static int Len(System.DateTime Expression)
      { return Expression.ToString().Length; }

      public static int Len(uint Expression)
      { return Expression.ToString().Length; }

      public static int Len(ulong Expression)
      { return Expression.ToString().Length; }

      public static int Len(ushort Expression)
      { return Expression.ToString().Length; }

      public static string LTrim(string str)
      { return str.TrimStart(Convert.ToChar(" ")); }

      public static string RTrim(string str)
      { return str.TrimEnd(Convert.ToChar(" ")); }

      public static string Trim(string str)
      { return str.Trim(Convert.ToChar(" ")); }

      public static string Mid(string str, int Start)
      { return str.Substring(Start); }

      public static string Mid(string str, int Start, int Length)
      { return str.Substring(Start, Length); }

      public static string Replace(string Expression, string Find, string Replacement, int Start = 1)
      {
        string str = Expression.Substring(Start);
        return str.Replace(Find, Replacement);
      }

    }

    public class Formats
    {

      public static string DateFormatString(DateTime value, DateFormat format)
      {
        string sFormat = string.Empty;
        if (format == DateFormat.NotZero) { sFormat = "d/M/yy"; }
        if (format == DateFormat.Day_Month_Year) { sFormat = "dd/MM/yyyy"; }
        if (format == DateFormat.Day_MonthName_Year) { sFormat = "dd/MMMM/yyyy"; }
        if (format == DateFormat.DayName_MonthName_Year) { sFormat = "dddd/MMMM/yyyy"; }
        if (format == DateFormat.Day_Month_YearTwoDigits) { sFormat = "dd/MM/yy"; }
        return value.ToString(sFormat);
      }

      public static string TimeFormatString(DateTime value, TimeFormat format)
      {
        string sFormat = string.Empty;
        if (format == TimeFormat.HourComplete_Minute) { sFormat = "HH:mm"; }
        if (format == TimeFormat.Hour_Minute) { sFormat = "hh:mm"; }
        if (format == TimeFormat.HourComplete_Minute_AMPM) { sFormat = "HH:mm tt"; }
        if (format == TimeFormat.Hour_Minute_AMPM) { sFormat = "hh:mm tt"; }
        if (format == TimeFormat.HourComplete_Minute_Second) { sFormat = "HH:mm:ss"; }
        if (format == TimeFormat.Hour_Minute_Second) { sFormat = "hh:mm:ss"; }
        if (format == TimeFormat.HourComplete_Minute_Second_AMPM) { sFormat = "HH:mm:ss tt"; }
        if (format == TimeFormat.Hour_Minute_Second_AMPM) { sFormat = "hh:mm:ss tt"; }
        return value.ToString(sFormat);
      }

      public static string FormatNumber(object value, int numdecimal, bool symbol)
      {
        string retorno = string.Empty;
        if (symbol) { retorno = decimal.Parse(value.ToString()).ToString("C" + numdecimal.ToString()); }
        else
        { retorno = decimal.Parse(value.ToString()).ToString("F" + numdecimal.ToString()); }
        return retorno;
      }

      public static string NumberToText(decimal number)
      {

        #region « Variables »

        string num = string.Empty;
        int longitud = 0;
        string numero = string.Empty;
        string Numero_o = string.Empty;
        string R = string.Empty;
        string decimal_ = string.Empty;
        string[] unidades; unidades = new string[10];
        string[] decenas; decenas = new string[10];
        string[] decenas_; decenas_ = new string[10];
        string[] decenas_1; decenas_1 = new string[10];
        string[] centenas; centenas = new string[10];
        double fr = 0;
        double tt = 0;
        double rr = 0;
        double ee = 0;

        #endregion

        #region « Inicializa Variables »

        num = number.ToString("F2");
        R = "";
        unidades[0] = "UNO"; unidades[1] = "UN"; unidades[2] = "DOS"; unidades[3] = "TRES"; unidades[4] = "CUATRO";
        unidades[5] = "CINCO"; unidades[6] = "SEIS"; unidades[7] = "SIETE"; unidades[8] = "OCHO"; unidades[9] = "NUEVE";

        decenas[0] = "DIEZ"; decenas[1] = "ONCE"; decenas[2] = "DOCE"; decenas[3] = "TRECE"; decenas[4] = "CATORCE";
        decenas[5] = "QUINCE"; decenas[6] = "DIECISEIS"; decenas[7] = "DIECISIETE"; decenas[8] = "DIECIOCHO"; decenas[9] = "DIECINUEVE";

        decenas_[0] = ""; decenas_[1] = ""; decenas_[2] = "VEINTE"; decenas_[3] = "TREINTA"; decenas_[4] = "CUARENTA";
        decenas_[5] = "CINCUENTA"; decenas_[6] = "SESENTA"; decenas_[7] = "SETENTA"; decenas_[8] = "OCHENTA"; decenas_[9] = "NOVENTA";

        decenas_1[0] = ""; decenas_1[1] = ""; decenas_1[2] = "VEINTI"; decenas_1[3] = "TREINTA"; decenas_1[4] = "CUARENTA";
        decenas_1[5] = "CINCUENTA"; decenas_1[6] = "SESENTA"; decenas_1[7] = "SETENTA"; decenas_1[8] = "OCHENTA"; decenas_1[9] = "NOVENTA";

        centenas[0] = "CIEN"; centenas[1] = "CIENTO"; centenas[2] = "DOCIENTOS"; centenas[3] = "TRECIENTOS"; centenas[4] = "CUATROCIENTOS";
        centenas[5] = "QUINIENTOS"; centenas[6] = "SEISCIENTOS"; centenas[7] = "SETECIENTOS"; centenas[8] = "OCHOCIENTOS"; centenas[9] = "NOVECIENTOS";

        #endregion

        #region « Proceso »

        Numero_o = Math.Truncate(decimal.Parse(num)).ToString();
        numero = Math.Truncate(decimal.Parse(num)).ToString();
        if (numero.Length > 6)
        {
          longitud = int.Parse(numero) - 6;
          numero = numero.Left(longitud);
          if (int.Parse(numero) == 3)
          {
            if (numero == "100") { R = centenas[0] + " "; }
            else
            {
              R = centenas[int.Parse(numero.Left(1))] + " ";
              numero = numero.Right(2);
            }
          }
          if (int.Parse(numero) == 2)
          {
            if (int.Parse(numero.Left(1)) == 1) { R = R + decenas[int.Parse(numero.Right(1))]; }
            else
            {
              if (int.Parse(numero.Right(1)) == 0) { R = R + decenas_[int.Parse(numero.Left(1))]; }
              else { R = R + decenas_1[int.Parse(numero.Left(1))] + " Y " + unidades[int.Parse(numero.Right(1))]; }
            }
          }
          fr = double.Parse(numero);
          if (int.Parse(numero) > 0 && numero.Length == 1)
          {
            if (int.Parse(numero) == 1) { R = R + unidades[1]; }
            else { R = R + unidades[int.Parse(numero)]; }
          }
          if (Numero_o.Length == 7 && Numero_o.Left(1) == "1") { R = R + " MILLON"; }
          else { R = R + " MILLONES "; }
          Numero_o = Numero_o.Right(6);
          numero = Numero_o;
        }
        if (int.Parse(numero).ToString().Length > 3)
        {
          longitud = numero.Length - 3;
          numero = int.Parse(numero.Left(longitud)).ToString().Trim();
          if (int.Parse(numero).ToString().Length == 3)
          {
            if (numero == "100") { R = R + centenas[0] + " "; }
            else
            {
              R = R + centenas[int.Parse(numero.Left(1))] + " ";
              numero = numero.Right(2);
            }
          }
          if (int.Parse(numero).ToString().Length == 2)
          {
            if (int.Parse(numero.Left(1)) == 1) { R = R + decenas[int.Parse(numero.Right(1))]; }
            else
            {
              if (int.Parse(numero.Right(1)) == 0) { R = R + decenas_[int.Parse(numero.Left(1))]; }
              else { R = R + decenas_1[int.Parse(numero.Left(1))] + " Y " + unidades[int.Parse(numero.Right(1))]; }
            }
          }
          fr = int.Parse(numero).ToString().Length;
          if (int.Parse(numero) > 0 && int.Parse(numero).ToString().Length == 1)
          {
            if (int.Parse(numero) == 1) { R = R + unidades[1]; }
            else { R = R + unidades[int.Parse(numero)]; }
          }
          Numero_o = Numero_o.Right(3);
          numero = Numero_o;
          R = R + " MIL ";
        }
        if (int.Parse(numero) > 0)
        {
          numero = int.Parse(numero).ToString().Trim();
          if (int.Parse(numero).ToString().Length == 3)
          {
            if (numero == "100") { R = R + centenas[0] + " "; }
            else
            {
              R = R + centenas[int.Parse(numero.Left(1))] + " ";
              numero = numero.Right(2);
            }
          }
          if (int.Parse(numero).ToString().Length == 2)
          {
            if (int.Parse(numero.ToString().Left(1)) == 1) { R = R + decenas[int.Parse(numero.ToString().Right(1))]; }
            else if (int.Parse(numero.ToString().Left(1)) == 2)
            {
              if (int.Parse(numero.Right(1)) == 0) { R = R + decenas_[int.Parse(numero.Left(1))]; }
              else { R = R + decenas_1[int.Parse(numero.Left(1))] + unidades[int.Parse(numero.Right(1))]; }
            }
            else
            {
              if (int.Parse(numero.Right(1)) == 0) { R = R + decenas_[int.Parse(numero.Left(1))]; }
              else { R = R + decenas_1[int.Parse(numero.Left(1))] + " Y " + unidades[int.Parse(numero.Right(1))]; }
            }
          }
          fr = int.Parse(numero).ToString().Length;
          if (int.Parse(numero) > 0 && int.Parse(numero).ToString().Length == 1)
          {
            if (int.Parse(numero) == 1) { R = R + unidades[0]; }
            else { R = R + unidades[int.Parse(numero)]; }
          }
          Numero_o = Numero_o.Right(3);
          numero = Numero_o;
        }
        tt = int.Parse(num.Trim());
        rr = (int)tt;
        ee = tt - (int)tt;
        decimal_ = num.Right(2);
        string lt = string.Empty;
        lt = R + " CON " + ((int.Parse(decimal_) < 10) ? "0" + int.Parse(decimal_).ToString().Trim() : decimal_) + "/100";

        #endregion

        return lt;

      }

    }

    public class Interaction
    {

      public static object IIf(bool Expression, object TruePart, object FalsePart)
      { return (Expression) ? TruePart : FalsePart; }

      public static object Choose(double Index, params object[] Choice)
      { return Choice[(int)Index]; }

      public static DataTable ToDataTable<T>(IList<T> data)
      {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
          PropertyDescriptor prop = props[i];
          table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
          for (int i = 0; i < values.Length; i++) { values[i] = props[i].GetValue(item); }
          table.Rows.Add(values);
        }
        return table;
      }

    }

    public class Information
    {

      public static bool IsArray(object VarName)
      {
        Type at = VarName.GetType();
        return at.IsArray;
      }

      public static bool IsDate(object Expression)
      {
        return DateTime.TryParse(Expression.ToString(), out DateTime dt);
      }

      public static bool IsDBNull(object Expression)
      { return Convert.IsDBNull(Expression); }

      public static bool IsNumeric(object Expression)
      {
        return int.TryParse(Expression.ToString(), out int result);
      }

    }

  }

}
