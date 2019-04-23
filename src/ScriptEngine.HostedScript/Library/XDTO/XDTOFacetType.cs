/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [EnumerationType("ВидФасетаXDTO", "XDTOFacetType")]
    public enum XDTOFacetType
    {
        [EnumItem("Длина", "Length")]
        Length,

        [EnumItem("МаксДлина", "MaxLength")]
        MaxLength,

        [EnumItem("МинДлина", "MinLength")]
        MinLength,

        [EnumItem("МаксВключающее", "MaxInclusive")]
        MaxInclusive,

        [EnumItem("МаксИсключающее", "MaxExclusive")]
        MaxExclusive,

        [EnumItem("МинВключающее", "MinInclusive")]
        MinInclusive,

        [EnumItem("МинИсключающее", "MinExclusive")]
        MinExclusive,

        [EnumItem("Образец", "Pattern")]
        Pattern,

        [EnumItem("Перечисление", "Enumeration")]
        Enumeration,

        [EnumItem("ПробельныеСимволы", "Whitespace")]
        Whitespace,

        [EnumItem("РазрядовВсего", "TotalDigits")]
        TotalDigits,

        [EnumItem("РазрядовДробнойЧасти", "FractionDigits")]
        FractionDigits
    }
}
