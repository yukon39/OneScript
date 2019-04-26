/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.HostedScript.Library.Xml;
using ScriptEngine.HostedScript.Library.XMLSchema;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    internal static class XDTOGlobal
    {
        public static XMLSchemaSet CoreSchemaSet()
        {
            XMLSchemaSet schemaSet = new XMLSchemaSet
            {
                //Schema(),
                DataCore()
            };

            schemaSet.Validate();
            return schemaSet;
        }

        private static XMLSchema.XMLSchema DataCore()
        {
            XMLSchema.XMLSchema schema = new XMLSchema.XMLSchema
            {
                TargetNamespace = "http://v8.1c.ru/8.1/data/core",
                AttributeFormDefault = XSForm.Unqualified,
                ElementFormDefault = XSForm.Qualified
            };

            schema.Content.Add(SimpleTypeUUID());

            return schema;

            XSSimpleTypeDefinition SimpleTypeUUID()
            {
                XSSimpleTypeDefinition simpleType = new XSSimpleTypeDefinition
                {
                    Name = "UUID",
                    Variety = XSSimpleTypeVariety.Atomic,
                    BaseTypeName = new XMLExpandedName(schema.SchemaForSchemaNamespaceURI, "string")
                };

                XSPatternFacet pattern = new XSPatternFacet
                {
                    Value = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}"
                };

                simpleType.Facets.Add(pattern);

                return simpleType;
            }
        }

        private static XMLSchema.XMLSchema Schema()
        {
            XMLSchema.XMLSchema schema = new XMLSchema.XMLSchema();
            schema.TargetNamespace = schema.SchemaForSchemaNamespaceURI;

            XSSimpleTypeDefinition simpleType = new XSSimpleTypeDefinition
            {
                Name = "string",
                //Variety = XSSimpleTypeVariety.Atomic,
                //BaseTypeName = new XMLExpandedName(schema.SchemaForSchemaNamespaceURI, "anySimpleType")
            };

            schema.Content.Add(simpleType);

            return schema;
        }
    }
}
