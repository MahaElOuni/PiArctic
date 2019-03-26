﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum Countries
    {

        Afghanistan,
        Albania,
        Algeria,
        AmericanSamoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        AntiguaandBarbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        BosniaandHerzegovina,
        Botswana,
        Brazil,
        Bulgaria,
        BurkinaFaso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        CapeVerde,
        CaymanIslands,
        CentralAfricanRepublic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo,
        CookIslands,
        CostaRica,
        CoteDIvoire,
        Croatia,
        Cuba,
        Cyprus,
        CzechRepublic,
        Denmark,
        Djibouti,
        Dominica,
        DominicanRepublic,
        Ecuador,
        Egypt,
        ElSalvador,
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Ethiopia,
        FaroeIslands,
        Fiji,
        Finland,
        France,
        FrenchGuiana,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        GuineaBissau,
        Guyana,
        Haiti,
        Honduras,
        HongKong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Korea, DemocraticPeoplesRepublicof,
        Republicofkorea,
        Kuwait,
        Kyrgyzstan,
        LaoPeoplsDemocraticRepublic,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        Macedonia, theFormerYugoslavRepublicof,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        MarshallIslands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        Micronesia, FederatedStatesof,
        RepublicofMoldova,
        Monaco,
        Mongolia,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        NetherlandsAntilles,
        NewCaledonia,
        NewZealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        NorfolkIsland,
        NorthernMarianaIslands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        PalestinianTerritory, Occupied,
        Panama,
        PapuaNewGuinea,
        Paraguay,
        Peru,
        Philippines,
        Pitcairn,
        Poland,
        Portugal,
        PuertoRico,
        Qatar,
        Reunion,
        Romania,
        RussianFederation,
        Rwanda,
        SaintKittsandNevis,
        SaintLucia,
        SaintPierreandMiquelon,
        SaintVincentandtheGrenadines,
        SanMarino,
        SaoTomandPrincipe,
        SaudiArabia,
        Senegal,
        SerbiaandMontenegro,
        Seychelles,
        SierraLeone,
        Singapore,
        Slovakia,
        Slovenia,
        SolomonIslands,
        Somalia,
        SouthAfrica,
        Spain,
        SriLanka,
        Sudan,
        Suriname,
        Swaziland,
        Sweden,
        Switzerland,
        Syria,
        Taiwan, ProvinceofChina,
        Tajikistan,
        Tanzania,
        Thailand,
        TimorLeste,
        Togo,
        Tokelau,
        Tonga,
        TrinidadandTobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        TurksandCaicosIslands,
        Tuvalu,
        Uganda,
        Ukraine,
        UnitedArabEmirates,
        UnitedKingdom,
        UnitedStates,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        VietNam,
        VirginIslands,
        US,
        WesternSahara,
        Yemen,
        Zambia,
        Zimbabwe
    }

    public enum Sex
    {
        Man, Women
    }

    public class Form
    {
        public int FormId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FormDate { get; set; }

        public int Age { get; set; }
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }

        public String Profession { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Mail { get; set; }
        [EnumDataType(typeof(Countries))]
        public Countries countrie { get; set; }
        [DataType(DataType.MultilineText)]
        public String Adresse { get; set; }
        [DataType(DataType.PostalCode)]
        public String CodePostal { get; set; }
        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }




    }
}
