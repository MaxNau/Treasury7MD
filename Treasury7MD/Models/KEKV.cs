
using System.ComponentModel.DataAnnotations.Schema;
using Treasury7MD.Helpers;

namespace Treasury7MD.Models
{
    public class KEKV
    {
        [NotMapped]
        public string Indicator { get; set; }
        [NotMapped]
        public string RowCode { get; set; }

        public int KEKVId { get; set; }
        public int Name { get; set; }
        public AccountsReceivable AccountsReceivable { get; set; }
        public AccountsPayable AccountsPayable { get; set; }
        public double RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod { get; set; }

        public KEKV()
        {
            AccountsReceivable = new AccountsReceivable();
            AccountsPayable = new AccountsPayable();
        }

        public enum KEKVCode
        {
            [KEKVDescription(Indicator = "Доходи", RowCode = "010")]
            K010 = 0,
            [KEKVDescription(Indicator = "Видатки - усього на утримання установи", RowCode = "020")]
            K020 = 1,
            [KEKVDescription(Indicator = "у тому числі: Поточні видатки", RowCode = "030")]
            K2000 = 2000,
            [KEKVDescription(Indicator = "Оплата праці і нарахування на заробітну плату", RowCode = "040")]
            K2100 = 2100,
            [KEKVDescription(Indicator = "Оплата праці", RowCode = "050")]
            K2110 = 2110,
            [KEKVDescription(Indicator = "Заробітна плата", RowCode = "060")]
            K2111 = 2111,
            [KEKVDescription(Indicator = "Грошове  забезпечення військовослужбовців", RowCode = "070")]
            K2112 = 2112,
            [KEKVDescription(Indicator = "Нарахування на  оплату праці", RowCode = "080")]
            K2120 = 2120,
            [KEKVDescription(Indicator = "Використання товарів і послуг", RowCode = "090")]
            K2200 = 2200,
            [KEKVDescription(Indicator = "Предмети, матеріали, обладнання та інвентар", RowCode = "100")]
            K2210 = 2210,
            [KEKVDescription(Indicator = "Медикаменти та перев’язувальні матеріали", RowCode = "110")]
            K2220 = 2220,
            [KEKVDescription(Indicator = "Продукти харчування", RowCode = "120")]
            K2230 = 2230,
            [KEKVDescription(Indicator = "Оплата послуг (крім комунальних)", RowCode = "130")]
            K2240 = 2240,
            [KEKVDescription(Indicator = "Видатки на відрядження", RowCode = "140")]
            K2250 = 2250,
            [KEKVDescription(Indicator = "Видатки та заходи спеціального призначення", RowCode = "150")]
            K2260 = 2260,
            [KEKVDescription(Indicator = "Оплата комунальних послуг та енергоносіїв", RowCode = "160")]
            K2270 = 2270,
            [KEKVDescription(Indicator = "Оплата теплопостачання", RowCode = "170")]
            K2271 = 2271,
            [KEKVDescription(Indicator = "Оплата водопостачання  та водовідведення", RowCode = "180")]
            K2272 = 2272,
            [KEKVDescription(Indicator = "Оплата електроенергії", RowCode = "190")]
            K2273 = 2273,
            [KEKVDescription(Indicator = "Оплата природного газу", RowCode = "200")]
            K2274 = 2274,
            [KEKVDescription(Indicator = "Оплата інших енергоносіїв", RowCode = "210")]
            K2275 = 2275,
            [KEKVDescription(Indicator = "Оплата енергосервісу", RowCode = "220")]
            K2276 = 2276,
            [KEKVDescription(Indicator = "Дослідження і розробки, окремі заходи по реалізації державних" +
                                         " (регіональних) програм", RowCode = "230")]
            K2280 = 2280,
            [KEKVDescription(Indicator = "Дослідження і розробки, окремі заходи розвитку по реалізації" +
                                         " державних (регіональних) програм", RowCode = "240")]
            K2281 = 2281,
            [KEKVDescription(Indicator = "Окремі заходи по реалізації державних (регіональних) програм," +
                                         " не віднесені до заходів розвитку", RowCode = "250")]
            K2282 = 2282,
            [KEKVDescription(Indicator = "Обслуговування боргових зобов’язань", RowCode = "260")]
            K2400 = 2400,
            [KEKVDescription(Indicator = "Обслуговування внутрішніх боргових зобов’язань ", RowCode = "270")]
            K2410 = 2410,
            [KEKVDescription(Indicator = "Обслуговування зовнішніх боргових зобов’язань ", RowCode = "280")]
            K2420 = 2420,
            [KEKVDescription(Indicator = "Поточні трансферти", RowCode = "290")]
            K2600 = 2600,
            [KEKVDescription(Indicator = "Субсидії та поточні трансферти підприємствам (установам," +
                                         " організаціям)", RowCode = "300")]
            K2610 = 2610,
            [KEKVDescription(Indicator = "Поточні трансферти органам державного управління інших" +
                                         " рівнів", RowCode = "310")]
            K2620 = 2620,
            [KEKVDescription(Indicator = "Поточні трансферти  урядам іноземних держав та міжнародним" +
                                         " організаціям", RowCode = "320")]
            K2630 = 2630,
            [KEKVDescription(Indicator = "Соціальне забезпечення", RowCode = "330")]
            K2700 = 2700,
            [KEKVDescription(Indicator = "Виплата пенсій і допомоги", RowCode = "340")]
            K2710 = 2710,
            [KEKVDescription(Indicator = "Стипендії", RowCode = "350")]
            K2720 = 2720,
            [KEKVDescription(Indicator = "Інші виплати населенню", RowCode = "360")]
            K2730 = 2730,
            [KEKVDescription(Indicator = "Інші поточні видатки", RowCode = "370")]
            K2800 = 2800,
            [KEKVDescription(Indicator = "Капітальні видатки", RowCode = "380")]
            K3000 = 3000,
            [KEKVDescription(Indicator = "Придбання основного капіталу*", RowCode = "390")]
            K3100 = 3100,
            [KEKVDescription(Indicator = "Придбання обладнання і предметів довгострокового" +
                                         " користування", RowCode = "400")]
            K3110 = 3110,
            [KEKVDescription(Indicator = "Капітальне будівництво (придбання)", RowCode = "410")]
            K3120 = 3120,
            [KEKVDescription(Indicator = "Капітальне будівництво (придбання) житла", RowCode = "420")]
            K3121 = 3121,
            [KEKVDescription(Indicator = "Капітальне  будівництво (придбання) інших об’єктів", RowCode = "430")]
            K3122 = 3122,
            [KEKVDescription(Indicator = "Капітальний ремонт", RowCode = "440")]
            K3130 = 3130,
            [KEKVDescription(Indicator = "Капітальний ремонт житлового фонду (приміщень)", RowCode = "450")]
            K3131 = 3131,
            [KEKVDescription(Indicator = "Капітальний ремонт інших об’єктів", RowCode = "460")]
            K3132 = 3132,
            [KEKVDescription(Indicator = "Реконструкція  та  реставрація", RowCode = "470")]
            K3140 = 3140,
            [KEKVDescription(Indicator = "Реконструкція житлового фонду (приміщень)", RowCode = "480")]
            K3141 = 3141,
            [KEKVDescription(Indicator = "Реконструкція та реставрація інших об’єктів", RowCode = "490")]
            K3142 = 3142,
            [KEKVDescription(Indicator = "Реставрація пам’яток культури, історії та архітектури", RowCode = "500")]
            K3143 = 3143,
            [KEKVDescription(Indicator = "Створення державних запасів і резервів", RowCode = "510")]
            K3150 = 3150,
            [KEKVDescription(Indicator = "Придбання землі  та нематеріальних активів", RowCode = "520")]
            K3160 = 3160,
            [KEKVDescription(Indicator = "Капітальні трансферти", RowCode = "530")]
            K3200 = 3200,
            [KEKVDescription(Indicator = "Капітальні трансферти підприємствам (установам, організаціям)", RowCode = "540")]
            K3210 = 3210,
            [KEKVDescription(Indicator = "Капітальні трансферти органам державного управління інших рівнів", RowCode = "550")]
            K3220 = 3220,
            [KEKVDescription(Indicator = "Капітальні трансферти  урядам іноземних держав та міжнародним організаціям", RowCode = "560")]
            K3230 = 3230,
            [KEKVDescription(Indicator = "Капітальні трансферти населенню", RowCode = "570")]
            K3240 = 3240
        }
       
    }
}
