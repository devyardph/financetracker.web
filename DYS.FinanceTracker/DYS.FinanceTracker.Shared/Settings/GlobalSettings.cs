

using DYS.FinanceTracker.Shared.Dtos;

namespace DYS.FinanceTracker.Shared.Settings
{
    public static class GlobalSettings
    {
        public const string PrivateAPI = "FinanceTracker.Private.API.Private";
        public const string PublicAPI = "FinanceTracker.Private.API.Public";
        public const string ExamineIndex = "DYS.JobHunter.Index";

        //EXISTING ROLES
        public const string Admin = "Admin";
        public const string Doctor = "Doctor";
        public const string Owner = "Owner";
        public const string Assistant = "Assistant";
        //CLAIMS
        public const string RoleClaimType = "roles";
        public const string EmailClaimType = "email";
        public const string NameClaimType = "name";

        //ACTION TYPES
        public const string Created = "created";
        public const string Modified = "modified";
        public const string Logged = "logged";
        public const string Sent = "sent";

        //SCHEDULE STATUS
        public const string InSchedule = "IN-SCHEDULE";
        public const string Walkin = "WALK-IN";
        public const string Waiting = "WAITING";
        public const string Ongoing = "ON-GOING";
        public const string NoShow = "NO-SHOW";
        public const string Rescheduled = "RE-SCHEDULED";
        public const string Completed = "COMPLETED";
        public const string Cancelled = "CANCELLED";
        //public const string Delete = "DELETE";

        //INOICE SETTINGS
        public const string Pending = "PENDING";
        public const string Paid = "PAID";
        public const string Overdue = "OVERDUE";
        //public const string Cancelled = "CANCELLED";


        public const string Cash = "CASH";
        public const string CreditCard = "CREDIT-CARD";
        public const string DigitalWallet = "DIGITAL-WALLET";
        public const string Check = "CHECK";
        public const string Others = "OTHERS";


        public const string Add = "ADD";
        public const string Edit = "EDIT";
        public const string Delete = "DELETE";
        public const string View = "VIEW";

        public const string Male = "MALE";
        public const string Female = "FEMALE";

        public static List<SelectDto> Genders = new List<SelectDto>() {
            new SelectDto(){ Id=Male, Name="Male",Description="Male", Style="" },
            new SelectDto(){ Id=Female, Name="Female",Description="Female", Style="" },
        };




        public static List<SelectDto> Religions = new List<SelectDto>() {
            new SelectDto(){ Id="aglipayan", Name="Philippine Independent Church (Aglipayan)", Description="Philippine Independent Church (Aglipayan)", Style="" },
            new SelectDto(){ Id="animism", Name="Animism", Description="Animism", Style="" },
            new SelectDto(){ Id="apostolic-catholic-church", Name="Apostolic Catholic Church", Description="Apostolic Catholic Church", Style="" },
            new SelectDto(){ Id="atheism", Name="Atheism", Description="Atheism", Style="" },
            new SelectDto(){ Id="bathalism", Name="Bathalism", Description="Bathalism", Style="" },
            new SelectDto(){ Id="buddhism", Name="Buddhism", Description="Buddhism", Style="" },
            new SelectDto(){ Id="church-of-jesus-christ-of-latter-day-saints-mormons", Name="Church of Jesus Christ of Latter-Day Saints (Mormons)", Description="Church of Jesus Christ of Latter-Day Saints (Mormons)", Style="" },
            new SelectDto(){ Id="hinduism", Name="Hinduism", Description="Hinduism", Style="" },
            new SelectDto(){ Id="iglesia-ni-cristo", Name="Iglesia ni Cristo", Description="Iglesia ni Cristo", Style="" },
            new SelectDto(){ Id="islam", Name="Islam", Description="Islam", Style="" },
            new SelectDto(){ Id="jehovahs-witnesses", Name="Jehovah’s Witnesses", Description="Jehovah’s Witnesses", Style="" },
            new SelectDto(){ Id="judaism", Name="Judaism", Description="Judaism", Style="" },
            new SelectDto(){ Id="members-church-of-god-international", Name="Members Church of God International", Description="Members Church of God International", Style="" },
            new SelectDto(){ Id="protestantism", Name="Protestantism", Description="Protestantism", Style="" },
            new SelectDto(){ Id="roman-catholicism", Name="Roman Catholicism", Description="Roman Catholicism", Style="" },
            new SelectDto(){ Id="seventh-day-adventist-church", Name="Seventh-day Adventist Church", Description="Seventh-day Adventist Church", Style="" },
            new SelectDto(){ Id="sikhism", Name="Sikhism", Description="Sikhism", Style="" },
            new SelectDto(){ Id="taoism", Name="Taoism", Description="Taoism", Style="" },
            new SelectDto(){ Id="z-others", Name="Others", Description="Others", Style="" }
};

        public static List<SelectDto> Nationalities = new List<SelectDto>() {
    new SelectDto("AF", "Afghanistan"),
    new SelectDto("AL", "Albania"),
    new SelectDto("DZ", "Algeria"),
    new SelectDto("AS", "American Samoa"),
    new SelectDto("AD", "Andorra"),
    new SelectDto("AO", "Angola"),
    new SelectDto("AI", "Anguilla"),
    new SelectDto("AQ", "Antarctica"),
    new SelectDto("AG", "Antigua and Barbuda"),
    new SelectDto("AR", "Argentina"),
    new SelectDto("AM", "Armenia"),
    new SelectDto("AW", "Aruba"),
    new SelectDto("AU", "Australia"),
    new SelectDto("AT", "Austria"),
    new SelectDto("AZ", "Azerbaijan"),
    new SelectDto("BS", "Bahamas"),
    new SelectDto("BH", "Bahrain"),
    new SelectDto("BD", "Bangladesh"),
    new SelectDto("BB", "Barbados"),
    new SelectDto("BY", "Belarus"),
    new SelectDto("BE", "Belgium"),
    new SelectDto("BZ", "Belize"),
    new SelectDto("BJ", "Benin"),
    new SelectDto("BM", "Bermuda"),
    new SelectDto("BT", "Bhutan"),
    new SelectDto("BO", "Bolivia"),
    new SelectDto("BA", "Bosnia and Herzegovina"),
    new SelectDto("BW", "Botswana"),
    new SelectDto("BR", "Brazil"),
    new SelectDto("IO", "British Indian Ocean Territory"),
    new SelectDto("BN", "Brunei Darussalam"),
    new SelectDto("BG", "Bulgaria"),
    new SelectDto("BF", "Burkina Faso"),
    new SelectDto("BI", "Burundi"),
    new SelectDto("KH", "Cambodia"),
    new SelectDto("CM", "Cameroon"),
    new SelectDto("CA", "Canada"),
    new SelectDto("CV", "Cape Verde"),
    new SelectDto("KY", "Cayman Islands"),
    new SelectDto("CF", "Central African Republic"),
    new SelectDto("TD", "Chad"),
    new SelectDto("CL", "Chile"),
    new SelectDto("CN", "China"),
    new SelectDto("CX", "Christmas Island"),
    new SelectDto("CC", "Cocos (Keeling) Islands"),
    new SelectDto("CO", "Colombia"),
    new SelectDto("KM", "Comoros"),
    new SelectDto("CG", "Congo"),
    new SelectDto("CD", "Congo, Democratic Republic"),
    new SelectDto("CK", "Cook Islands"),
    new SelectDto("CR", "Costa Rica"),
    new SelectDto("HR", "Croatia"),
    new SelectDto("CU", "Cuba"),
    new SelectDto("CY", "Cyprus"),
    new SelectDto("CZ", "Czech Republic"),
    new SelectDto("DK", "Denmark"),
    new SelectDto("DJ", "Djibouti"),
    new SelectDto("DM", "Dominica"),
    new SelectDto("DO", "Dominican Republic"),
    new SelectDto("EC", "Ecuador"),
    new SelectDto("EG", "Egypt"),
    new SelectDto("SV", "El Salvador"),
    new SelectDto("GQ", "Equatorial Guinea"),
    new SelectDto("ER", "Eritrea"),
    new SelectDto("EE", "Estonia"),
    new SelectDto("ET", "Ethiopia"),
    new SelectDto("FK", "Falkland Islands"),
    new SelectDto("FO", "Faroe Islands"),
    new SelectDto("FJ", "Fiji"),
    new SelectDto("FI", "Finland"),
    new SelectDto("FR", "France"),
    new SelectDto("GF", "French Guiana"),
    new SelectDto("PF", "French Polynesia"),
    new SelectDto("GA", "Gabon"),
    new SelectDto("GM", "Gambia"),
    new SelectDto("GE", "Georgia"),
    new SelectDto("DE", "Germany"),
    new SelectDto("GH", "Ghana"),
    new SelectDto("GI", "Gibraltar"),
    new SelectDto("GR", "Greece"),
    new SelectDto("GL", "Greenland"),
    new SelectDto("GD", "Grenada"),
    new SelectDto("GP", "Guadeloupe"),
    new SelectDto("GU", "Guam"),
    new SelectDto("GT", "Guatemala"),
    new SelectDto("GN", "Guinea"),
    new SelectDto("GW", "Guinea-Bissau"),
    new SelectDto("GY", "Guyana"),
    new SelectDto("HT", "Haiti"),
    new SelectDto("HN", "Honduras"),
    new SelectDto("HK", "Hong Kong"),
    new SelectDto("HU", "Hungary"),
    new SelectDto("IS", "Iceland"),
    new SelectDto("IN", "India"),
    new SelectDto("ID", "Indonesia"),
    new SelectDto("IR", "Iran"),
    new SelectDto("IQ", "Iraq"),
    new SelectDto("IE", "Ireland"),
    new SelectDto("IL", "Israel"),
    new SelectDto("IT", "Italy"),
    new SelectDto("CI", "Ivory Coast"),
    new SelectDto("JM", "Jamaica"),
    new SelectDto("JP", "Japan"),
    new SelectDto("JO", "Jordan"),
    new SelectDto("KZ", "Kazakhstan"),
    new SelectDto("KE", "Kenya"),
    new SelectDto("KI", "Kiribati"),
    new SelectDto("KW", "Kuwait"),
    new SelectDto("KG", "Kyrgyzstan"),
    new SelectDto("LA", "Laos"),
    new SelectDto("LV", "Latvia"),
    new SelectDto("LB", "Lebanon"),
    new SelectDto("LS", "Lesotho"),
    new SelectDto("LR", "Liberia"),
    new SelectDto("LY", "Libya"),
    new SelectDto("LI", "Liechtenstein"),
    new SelectDto("LT", "Lithuania"),
    new SelectDto("LU", "Luxembourg"),
    new SelectDto("MO", "Macau"),
    new SelectDto("MK", "Macedonia"),
    new SelectDto("MG", "Madagascar"),
    new SelectDto("MW", "Malawi"),
    new SelectDto("MY", "Malaysia"),
    new SelectDto("MV", "Maldives"),
    new SelectDto("ML", "Mali"),
    new SelectDto("MT", "Malta"),
    new SelectDto("MH", "Marshall Islands"),
    new SelectDto("MQ", "Martinique"),
    new SelectDto("MR", "Mauritania"),
    new SelectDto("MU", "Mauritius"),
    new SelectDto("YT", "Mayotte"),
    new SelectDto("MX", "Mexico"),
    new SelectDto("FM", "Micronesia"),
    new SelectDto("MD", "Moldova"),
    new SelectDto("MC", "Monaco"),
    new SelectDto("MN", "Mongolia"),
    new SelectDto("ME", "Montenegro"),
    new SelectDto("MS", "Montserrat"),
    new SelectDto("MA", "Morocco"),
    new SelectDto("MZ", "Mozambique"),
    new SelectDto("MM", "Myanmar"),
    new SelectDto("NA", "Namibia"),
    new SelectDto("NR", "Nauru"),
    new SelectDto("NP", "Nepal"),
    new SelectDto("NL", "Netherlands"),
    new SelectDto("NC", "New Caledonia"),
    new SelectDto("NZ", "New Zealand"),
    new SelectDto("NI", "Nicaragua"),
    new SelectDto("NE", "Niger"),
    new SelectDto("NG", "Nigeria"),
    new SelectDto("NU", "Niue"),
    new SelectDto("NF", "Norfolk Island"),
    new SelectDto("KP", "North Korea"),
    new SelectDto("MP", "Northern Mariana Islands"),
    new SelectDto("NO", "Norway"),
    new SelectDto("OM", "Oman"),
    new SelectDto("PK", "Pakistan"),
    new SelectDto("PW", "Palau"),
    new SelectDto("PA", "Panama"),
    new SelectDto("PG", "Papua New Guinea"),
    new SelectDto("PY", "Paraguay"),
    new SelectDto("PE", "Peru"),
    new SelectDto("PH", "Philippines"),
    new SelectDto("PL", "Poland"),
    new SelectDto("PT", "Portugal"),
    new SelectDto("PR", "Puerto Rico"),
    new SelectDto("QA", "Qatar"),
    new SelectDto("RE", "Reunion"),
    new SelectDto("RO", "Romania"),
    new SelectDto("RU", "Russia"),
    new SelectDto("RW", "Rwanda"),
    new SelectDto("KN", "Saint Kitts and Nevis"),
    new SelectDto("LC", "Saint Lucia"),
    new SelectDto("VC", "Saint Vincent and the Grenadines"),
    new SelectDto("WS", "Samoa"),
    new SelectDto("SM", "San Marino"),
    new SelectDto("ST", "Sao Tome and Principe"),
    new SelectDto("SA", "Saudi Arabia"),
    new SelectDto("SN", "Senegal"),
    new SelectDto("RS", "Serbia"),
    new SelectDto("SC", "Seychelles"),
    new SelectDto("SL", "Sierra Leone"),
    new SelectDto("SG", "Singapore"),
    new SelectDto("SK", "Slovakia"),
    new SelectDto("SI", "Slovenia"),
    new SelectDto("SB", "Solomon Islands"),
    new SelectDto("SO", "Somalia"),
    new SelectDto("ZA", "South Africa"),
    new SelectDto("KR", "South Korea"),
    new SelectDto("ES", "Spain"),
    new SelectDto("LK", "Sri Lanka"),
    new SelectDto("SD", "Sudan"),
    new SelectDto("SR", "Suriname"),
    new SelectDto("SZ", "Swaziland"),
    new SelectDto("SE", "Sweden"),
    new SelectDto("CH", "Switzerland"),
    new SelectDto("SY", "Syria"),
    new SelectDto("TW", "Taiwan"),
    new SelectDto("TJ", "Tajikistan"),
    new SelectDto("TZ", "Tanzania"),
    new SelectDto("TH", "Thailand"),
    new SelectDto("TG", "Togo"),
    new SelectDto("TO", "Tonga"),
    new SelectDto("TT", "Trinidad and Tobago"),
    new SelectDto("TN", "Tunisia"),
    new SelectDto("TR", "Turkey"),
    new SelectDto("TM", "Turkmenistan"),
    new SelectDto("TV", "Tuvalu"),
    new SelectDto("UG", "Uganda"),
    new SelectDto("UA", "Ukraine"),
    new SelectDto("AE", "United Arab Emirates"),
    new SelectDto("GB", "United Kingdom"),
    new SelectDto("US", "United States"),
    new SelectDto("UY", "Uruguay"),
    new SelectDto("UZ", "Uzbekistan"),
    new SelectDto("VU", "Vanuatu"),
    new SelectDto("VE", "Venezuela"),
    new SelectDto("VN", "Vietnam"),
    new SelectDto("YE", "Yemen"),
    new SelectDto("ZM", "Zambia"),
    new SelectDto("ZW", "Zimbabwe")
};

        public static List<SelectDto> Occupations = new List<SelectDto>() {
    new SelectDto(){ Id="accountant", Name="Accountant", Description="Accountant"},
    new SelectDto(){ Id="actor", Name="Actor", Description="Actor"},
    new SelectDto(){ Id="architect", Name="Architect", Description="Architect"},
    new SelectDto(){ Id="artist", Name="Artist", Description="Artist"},
    new SelectDto(){ Id="attorney", Name="Attorney", Description="Attorney"},
    new SelectDto(){ Id="barber", Name="Barber", Description="Barber"},
    new SelectDto(){ Id="chef", Name="Chef", Description="Chef"},
    new SelectDto(){ Id="civil-engineer", Name="Civil Engineer", Description="Civil Engineer"},
    new SelectDto(){ Id="clerk", Name="Clerk", Description="Clerk"},
    new SelectDto(){ Id="construction-worker", Name="Construction Worker", Description="Construction Worker"},
    new SelectDto(){ Id="dentist", Name="Dentist", Description="Dentist"},
    new SelectDto(){ Id="designer", Name="Designer", Description="Designer"},
    new SelectDto(){ Id="developer", Name="Developer", Description="Developer"},
    new SelectDto(){ Id="doctor", Name="Doctor", Description="Doctor"},
    new SelectDto(){ Id="driver", Name="Driver", Description="Driver"},
    new SelectDto(){ Id="electrician", Name="Electrician", Description="Electrician"},
    new SelectDto(){ Id="engineer", Name="Engineer", Description="Engineer"},
    new SelectDto(){ Id="farmer", Name="Farmer", Description="Farmer"},
    new SelectDto(){ Id="firefighter", Name="Firefighter", Description="Firefighter"},
    new SelectDto(){ Id="graphic-designer", Name="Graphic Designer", Description="Graphic Designer"},
    new SelectDto(){ Id="hair-stylist", Name="Hair Stylist", Description="Hair Stylist"},
    new SelectDto(){ Id="journalist", Name="Journalist", Description="Journalist"},
    new SelectDto(){ Id="lawyer", Name="Lawyer", Description="Lawyer"},
    new SelectDto(){ Id="librarian", Name="Librarian", Description="Librarian"},
    new SelectDto(){ Id="mechanic", Name="Mechanic", Description="Mechanic"},
    new SelectDto(){ Id="nurse", Name="Nurse", Description="Nurse"},
    new SelectDto(){ Id="none", Name="None", Description="None"},
    new SelectDto(){ Id="painter", Name="Painter", Description="Painter"},
    new SelectDto(){ Id="pharmacist", Name="Pharmacist", Description="Pharmacist"},
    new SelectDto(){ Id="photographer", Name="Photographer", Description="Photographer"},
    new SelectDto(){ Id="pilot", Name="Pilot", Description="Pilot"},
    new SelectDto(){ Id="plumber", Name="Plumber", Description="Plumber"},
    new SelectDto(){ Id="police-officer", Name="Police Officer", Description="Police Officer"},
    new SelectDto(){ Id="professor", Name="Professor", Description="Professor"},
    new SelectDto(){ Id="programmer", Name="Programmer", Description="Programmer"},
    new SelectDto(){ Id="receptionist", Name="Receptionist", Description="Receptionist"},
    new SelectDto(){ Id="salesperson", Name="Salesperson", Description="Salesperson"},
    new SelectDto(){ Id="scientist", Name="Scientist", Description="Scientist"},
    new SelectDto(){ Id="software-engineer", Name="Software Engineer", Description="Software Engineer"},
    new SelectDto(){ Id="student", Name="Student", Description="Student"},
    new SelectDto(){ Id="surgeon", Name="Surgeon", Description="Surgeon"},
    new SelectDto(){ Id="teacher", Name="Teacher", Description="Teacher"},
    new SelectDto(){ Id="technician", Name="Technician", Description="Technician"},
    new SelectDto(){ Id="translator", Name="Translator", Description="Translator"},
    new SelectDto(){ Id="veterinarian", Name="Veterinarian", Description="Veterinarian"},
    new SelectDto(){ Id="waiter", Name="Waiter", Description="Waiter"},
    new SelectDto(){ Id="writer", Name="Writer", Description="Writer"},
    new SelectDto(){ Id="z-other", Name="Other", Description="Other"}
};

        public static List<SelectDto> Recurrence = new List<SelectDto>() {
            new SelectDto(){ Id="one-time", Name="one-time",Description="one-time", Style="" },
            new SelectDto(){ Id="daily", Name="daily",Description="daily", Style="" },
            new SelectDto(){ Id="weekly", Name="weekly",Description="weekly", Style="" },
            new SelectDto(){ Id="monthly", Name="monthly",Description="monthly", Style="" },
            new SelectDto(){ Id="yearly", Name="yearly",Description="yearly", Style="" },
        };

        public static List<SelectDto> Categories = new List<SelectDto>() {
    // Expense Categories
    new SelectDto(){ Parent="expense", Id="housing", Name="Housing", Description="Mortgage, rent, property taxes, maintenance", Style="", Icon="bx-home" },
    new SelectDto(){ Parent="expense", Id="utilities", Name="Utilities", Description="Electricity, water, gas, internet, phone", Style="", Icon="bx-plug" },
    new SelectDto(){ Parent="expense", Id="food-and-dining", Name="Food & Dining", Description="Groceries, dining out, coffee shops", Style="", Icon="bx-restaurant" },
    new SelectDto(){ Parent="expense", Id="transport", Name="Transport", Description="Fuel, insurance, public transit, parking", Style="", Icon="bx-bus" },
    new SelectDto(){ Parent="expense", Id="car-amortization", Name="Car Amortization", Description="Car loan payments, financing costs", Style="", Icon="bx-car" },
    new SelectDto(){ Parent="expense", Id="healthcare", Name="Healthcare", Description="Medical bills, insurance, prescriptions", Style="", Icon="bx-first-aid" },
    new SelectDto(){ Parent="expense", Id="insurance", Name="Insurance", Description="Life, home, auto, health premiums", Style="", Icon="bx-shield" },
    new SelectDto(){ Parent="expense", Id="entertainment", Name="Entertainment", Description="Movies, streaming, hobbies, sports", Style="", Icon="bx-movie-play" },
    new SelectDto(){ Parent="expense", Id="shopping", Name="Shopping", Description="Clothing, electronics, household goods", Style="", Icon="bx-shopping-bag" },
    new SelectDto(){ Parent="expense", Id="education", Name="Education", Description="Tuition, books, courses, training", Style="", Icon="bx-book-open" },
    new SelectDto(){ Parent="expense", Id="childcare", Name="Childcare", Description="Daycare, babysitting, school fees", Style="", Icon="bx-child" },
    new SelectDto(){ Parent="expense", Id="personal-care", Name="Personal Care", Description="Haircuts, salon, cosmetics", Style="", Icon="bx-user-circle" },
    new SelectDto(){ Parent="expense", Id="subscriptions", Name="Subscriptions", Description="Magazines, apps, memberships", Style="", Icon="bx-credit-card" },
    new SelectDto(){ Parent="expense", Id="gifts-donations", Name="Gifts & Donations", Description="Charity, family gifts, tithes", Style="", Icon="bx-gift" },
    new SelectDto(){ Parent="expense", Id="travel", Name="Travel", Description="Flights, hotels, vacations", Style="", Icon="bx-plane-alt" },
    new SelectDto(){ Parent="expense", Id="pets", Name="Pets", Description="Food, vet, grooming", Style="", Icon="bx-bone" },
    new SelectDto(){ Parent="expense", Id="debt-payments", Name="Debt Payments", Description="Credit cards, loans, interest", Style="", Icon="bx-money" },
    new SelectDto(){ Parent="expense", Id="other", Name="Other", Description="Miscellaneous expenses", Style="", Icon="bx-dots-horizontal-rounded" },

    // Income Categories
    new SelectDto(){ Parent="income", Id="salary", Name="Salary", Description="Regular wages from employment", Style="", Icon="bx-briefcase" },
    new SelectDto(){ Parent="income", Id="freelance", Name="Freelance", Description="Contract work, consulting", Style="", Icon="bx-laptop" },
    new SelectDto(){ Parent="income", Id="business", Name="Business", Description="Self-employment, side hustles", Style="", Icon="bx-store" },
    new SelectDto(){ Parent="income", Id="investment", Name="Investment", Description="Dividends, interest, capital gains", Style="", Icon="bx-line-chart" },
    new SelectDto(){ Parent="income", Id="rental", Name="Rental Income", Description="Property rentals, Airbnb", Style="", Icon="bx-building-house" },
    new SelectDto(){ Parent="income", Id="royalties", Name="Royalties", Description="Books, music, patents", Style="", Icon="bx-music" },
    new SelectDto(){ Parent="income", Id="pension", Name="Pension/Retirement", Description="Social security, retirement funds", Style="", Icon="bx-wallet" },
    new SelectDto(){ Parent="income", Id="gift", Name="Gift", Description="Cash gifts, allowances", Style="", Icon="bx-gift" },
    new SelectDto(){ Parent="income", Id="government-benefits", Name="Government Benefits", Description="Unemployment, child support, subsidies", Style="", Icon="bx-bank" },
    new SelectDto(){ Parent="income", Id="other", Name="Other", Description="Miscellaneous income", Style="", Icon="bx-dots-horizontal-rounded" },
};




        public static List<SelectDto> AccountType = new List<SelectDto>() {
            new SelectDto(){ Id="cash", Name="Cash",Description="Cash", Style="bg-info" },
            new SelectDto(){ Id="bank", Name="Bank",Description="Bank", Style="bg-primary" },
            new SelectDto(){ Id="credit", Name="Credit",Description="Credit", Style="bg-warning" },
            new SelectDto(){ Id="investment", Name="Investment",Description="Investment", Style="bg-success" },
            new SelectDto(){ Id="wallet", Name="Wallet",Description="Wallet", Style="bg-secondary" }
        };

 public static List<SelectDto> Currencies = new List<SelectDto>()
{
    new SelectDto(){ Id="USD", Name="US Dollar", Description="United States Dollar", Style="" },
    new SelectDto(){ Id="EUR", Name="Euro", Description="European Union Euro", Style="" },
    new SelectDto(){ Id="GBP", Name="British Pound", Description="United Kingdom Pound Sterling", Style="" },
    new SelectDto(){ Id="JPY", Name="Japanese Yen", Description="Japan Yen", Style="" },
    new SelectDto(){ Id="CNY", Name="Chinese Yuan", Description="China Yuan Renminbi", Style="" },
    new SelectDto(){ Id="AUD", Name="Australian Dollar", Description="Australia Dollar", Style="" },
    new SelectDto(){ Id="CAD", Name="Canadian Dollar", Description="Canada Dollar", Style="" },
    new SelectDto(){ Id="CHF", Name="Swiss Franc", Description="Switzerland Franc", Style="" },
    new SelectDto(){ Id="NZD", Name="New Zealand Dollar", Description="New Zealand Dollar", Style="" },
    new SelectDto(){ Id="PHP", Name="Philippine Peso", Description="Philippines Peso", Style="" },
    new SelectDto(){ Id="SGD", Name="Singapore Dollar", Description="Singapore Dollar", Style="" },
    new SelectDto(){ Id="HKD", Name="Hong Kong Dollar", Description="Hong Kong Dollar", Style="" },
    new SelectDto(){ Id="INR", Name="Indian Rupee", Description="India Rupee", Style="" },
    new SelectDto(){ Id="KRW", Name="South Korean Won", Description="South Korea Won", Style="" },
    new SelectDto(){ Id="SEK", Name="Swedish Krona", Description="Sweden Krona", Style="" },
    new SelectDto(){ Id="NOK", Name="Norwegian Krone", Description="Norway Krone", Style="" },
    new SelectDto(){ Id="DKK", Name="Danish Krone", Description="Denmark Krone", Style="" },
    new SelectDto(){ Id="MXN", Name="Mexican Peso", Description="Mexico Peso", Style="" },
    new SelectDto(){ Id="BRL", Name="Brazilian Real", Description="Brazil Real", Style="" },
    new SelectDto(){ Id="ZAR", Name="South African Rand", Description="South Africa Rand", Style="" }
};

    }
}