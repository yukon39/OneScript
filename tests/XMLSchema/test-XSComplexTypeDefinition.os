Перем ЮнитТест;

#Область ОбработчикиСобытийМодуля

Функция ПолучитьСписокТестов(МенеджерТестирования) Экспорт
	
	ЮнитТест = МенеджерТестирования;

	СписокТестов = Новый Массив;
	СписокТестов.Добавить("ТестКонструктор");
	СписокТестов.Добавить("TestConstructor");
	СписокТестов.Добавить("ТестИмя");
	СписокТестов.Добавить("ТестДобавитьГруппуАтрибутов");
	СписокТестов.Добавить("ТестАннотация");
	
	Возврат СписокТестов;

КонецФункции

#КонецОбласти

#Область ОбработчикиТестирования

Процедура ТестКонструктор() Экспорт

	ОпределениеТипа = Новый ОпределениеСоставногоТипаXS;
	
	ЮнитТест.ПроверитьРавенство(ТипЗнч(ОпределениеТипа), Тип("ОпределениеСоставногоТипаXS"));
	ЮнитТест.ПроверитьРавенство(ОпределениеТипа.ТипКомпоненты, ТипКомпонентыXS.ОпределениеСоставногоТипа);
	ЮнитТест.ПроверитьРавенство(ТипЗнч(ОпределениеТипа.Компоненты), Тип("ФиксированныйСписокКомпонентXS"));
	ЮнитТест.ПроверитьРавенство(ТипЗнч(ОпределениеТипа.Атрибуты), Тип("СписокКомпонентXS"));

КонецПроцедуры

Procedure TestConstructor() Export

	TypeDefinition = New XSComplexTypeDefinition;

	ЮнитТест.ПроверитьРавенство(TypeOf(TypeDefinition), Type("XSComplexTypeDefinition"));
	ЮнитТест.ПроверитьРавенство(TypeDefinition.ComponentType, XSComponentType.ComplexTypeDefinition);

EndProcedure

Процедура ТестИмя() Экспорт

	ОпределениеТипа = Новый ОпределениеСоставногоТипаXS;

	ОпределениеТипа.Имя = "test";

	ЮнитТест.ПроверитьРавенство(ОпределениеТипа.Имя, "test");

КонецПроцедуры

Процедура ТестДобавитьГруппуАтрибутов() Экспорт

	ОпределениеТипа = Новый ОпределениеСоставногоТипаXS;

	АтрибутСсылка = Новый ОпределениеГруппыАтрибутовXS;
	АтрибутСсылка.Ссылка = Новый РасширенноеИмяXML("http://www.w3.org/2001/XMLSchema", "string");
	ОпределениеТипа.Атрибуты.Добавить(АтрибутСсылка);

	ЮнитТест.ПроверитьРавенство(ОпределениеТипа.Атрибуты.Количество(), 1);
	ЮнитТест.ПроверитьРавенство(ОпределениеТипа.Компоненты.Количество(), 1);
	ЮнитТест.ПроверитьРавенство(АтрибутСсылка.Контейнер, ОпределениеТипа);

КонецПроцедуры

Процедура ТестАннотация() Экспорт

	ОпределениеТипа = Новый ОпределениеСоставногоТипаXS;

	Аннотация = Новый АннотацияXS;
	ОпределениеТипа.Аннотация = Аннотация;

	ЮнитТест.ПроверитьРавенство(ОпределениеТипа.Аннотация, Аннотация);
	ЮнитТест.ПроверитьРавенство(Аннотация.Контейнер, ОпределениеТипа);

КонецПроцедуры

#КонецОбласти