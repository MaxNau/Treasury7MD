using System.Collections.ObjectModel;
using System.Data.OleDb;
using Treasury7MD.Model;

namespace Treasury7MD.Models.DBF
{
    public class DbfProvider
    {
        private static void CreateForm7DBFTable(string path)
        {
            using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + path))
            {
                con.Open();
                //Creating clients.dbf table
                OleDbCommand create = con.CreateCommand();
                create.CommandText = "CREATE TABLE [" + "Table" + "] ([KB] numeric(0), [EDRPOY] char(10), [KVK] numeric(2), [KFK] numeric(6)," +
                    "[KOD] char(20), [ID_] char(3), [KPOL] char(5), [UDK] numeric(1), [RAY] numeric(1), [RVDK] numeric(1)," +
                    "[DATEIDEN] date, [N1] numeric(13,2), [N2] numeric(13,2), [N3] numeric(13,2), [N4] numeric(13,2)," +
                    "[N5] numeric(13,2), [N6] numeric(13,2), [N7] numeric(13,2), [N8] numeric(13,2), [N9] numeric(13,2)," +
                    "[N10] numeric(13,2), [N11] numeric(13,2), [N12] numeric(13,2), [N13] numeric(13,2), [N14] numeric(13,2)," +
                    "[N15] numeric(13,2), [N16] numeric(13,2), [N17] numeric(13,2), [N18] numeric(13,2), [N19] numeric(13,2))";
                create.ExecuteNonQuery();
            }
        }

        public static void ExportForm7ToDBF(string path, ObservableCollection<KEKV> KEKVs)
        {
            CreateForm7DBFTable(path);

            using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + path))
            {
                con.Open();
                //Creating clients.dbf table
                string insertString = "insert into Table (KB, EDRPOY, KVK, KFK, KOD, ID_, KPOL, UDK, RAY, RVDK, DATEIDEN, N1," +
                    "N2, N3, N4, N5, N6, N7, N8, N9, N10, N11, N12, N13, N14, N15, N16, N17, N18, N19) values (?, ?, ?, ?, ?," +
                    "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                OleDbCommand insert = new OleDbCommand(insertString, con);

                foreach (KEKV kekv in KEKVs)
                {
                    if (IsEmptyKekvRecord(kekv))
                    {
                        System.DateTime orddate = System.DateTime.ParseExact("11/02/2016", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        insert.Parameters.AddWithValue("KB", 1);
                        insert.Parameters.AddWithValue("EDRPOY", "ss");
                        insert.Parameters.AddWithValue("KVK", 1);
                        insert.Parameters.AddWithValue("KFK", 1);
                        insert.Parameters.AddWithValue("KOD", "ww");
                        insert.Parameters.AddWithValue("ID_", "1");
                        insert.Parameters.AddWithValue("KPOL", "22");
                        insert.Parameters.AddWithValue("UDK", 1);
                        insert.Parameters.AddWithValue("RAY", 1);
                        insert.Parameters.AddWithValue("RVDK", 1);
                        insert.Parameters.AddWithValue("DATEIDEN", orddate);
                        insert.Parameters.AddWithValue("N1", kekv.AccountsReceivable.AtTheBeginingOfTheYear);
                        insert.Parameters.AddWithValue("N2", kekv.AccountsReceivable.AtTheEndOfTheReportingPeriod);
                        insert.Parameters.AddWithValue("N3", kekv.AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod);
                        insert.Parameters.AddWithValue("N4", kekv.AccountsReceivable.WrittenOffSinceTheBeginningOfTheYear);
                        insert.Parameters.AddWithValue("N5", kekv.AccountsPayable.AtTheBeginingOfTheYear);
                        insert.Parameters.AddWithValue("N6", kekv.AccountsPayable.AtTheEndOfTheReportingPeriod);
                        insert.Parameters.AddWithValue("N7", kekv.AccountsPayable.OverdueAtTheEndOfTheReportingPeriod);
                        insert.Parameters.AddWithValue("N8", kekv.AccountsPayable.DebtNotDue);
                        insert.Parameters.AddWithValue("N9", kekv.AccountsPayable.WrittenOffSinceTheBeginningOfTheYear);
                        insert.Parameters.AddWithValue("N10", kekv.RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod);
                        insert.Parameters.AddWithValue("N11", 1);
                        insert.Parameters.AddWithValue("N12", 1);
                        insert.Parameters.AddWithValue("N13", 1);
                        insert.Parameters.AddWithValue("N14", 1);
                        insert.Parameters.AddWithValue("N15", 1);
                        insert.Parameters.AddWithValue("N16", 1);
                        insert.Parameters.AddWithValue("N17", 1);
                        insert.Parameters.AddWithValue("N18", 1);
                        insert.Parameters.AddWithValue("N19", 1);
                        insert.ExecuteNonQuery();
                    }
                }
            }
        }

        private static bool IsEmptyKekvRecord(KEKV kekv)
        {
            return kekv.AccountsReceivable.AtTheBeginingOfTheYear > 0 || kekv.AccountsReceivable.AtTheEndOfTheReportingPeriod > 0 ||
                 kekv.AccountsReceivable.OverdueAtTheEndOfTheReportingPeriod > 0 || kekv.AccountsReceivable.WrittenOffSinceTheBeginningOfTheYear > 0 ||
                kekv.AccountsPayable.AtTheBeginingOfTheYear > 0 || kekv.AccountsPayable.AtTheEndOfTheReportingPeriod > 0 ||
                kekv.AccountsPayable.OverdueAtTheEndOfTheReportingPeriod > 0 || kekv.AccountsPayable.DebtNotDue > 0 ||
                kekv.AccountsPayable.WrittenOffSinceTheBeginningOfTheYear > 0;
        }
    }
}
