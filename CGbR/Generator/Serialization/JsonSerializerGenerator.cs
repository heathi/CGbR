﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CGbR
{
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class JsonSerializerGenerator : JsonSerializerGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"        /// <summary>
        /// Convert object to JSON string
        /// </summary>
        public string ToJson()
        {
            var builder = new StringBuilder();
            IncludeJson(builder);
            return builder.ToString();
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public void IncludeJson(StringBuilder writer)
        {
            writer.Append('{');

");
            
            #line 25 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

    var first = true;
    foreach (var property in Model.Properties.WhereAttribute(nameof(DataMemberAttribute)))
    {
        

            
            #line default
            #line hidden
            this.Write("            writer.Append(\"");
            
            #line 31 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(first ? string.Empty : ","));
            
            #line default
            #line hidden
            this.Write("\\\"");
            
            #line 31 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write("\\\":\");\r\n");
            
            #line 32 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

        if (property.IsCollection)
        {

            
            #line default
            #line hidden
            this.Write("            if (");
            
            #line 36 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write(" == null)\r\n                writer.Append(\"null\");\r\n            else\r\n            " +
                    "{\r\n                writer.Append(\'[\');\r\n                foreach (var value in ");
            
            #line 41 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n                {\r\n");
            
            #line 43 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

        }
        var target = property.IsCollection ? "value" : property.Name;
        if (property.ValueType == ValueType.String)
            target = $"string.Format(\"\\\"{{0}}\\\"\", {target})";
        else if(property.ValueType != ValueType.Class)
            target = $"{target}.ToString(CultureInfo.InvariantCulture)";

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 51 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.IsCollection ? "\t\t" : string.Empty));
            
            #line default
            #line hidden
            
            #line 51 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.ValueType == ValueType.Class ? $"{target}.IncludeJson(writer)" : $"writer.Append({target})"));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 52 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

        if (property.IsCollection)
        {

            
            #line default
            #line hidden
            this.Write("                    writer.Append(\',\');\r\n                }\r\n                write" +
                    "r.Append(\']\');\r\n            }\r\n");
            
            #line 60 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            
        }

            
            #line default
            #line hidden
            this.Write("    \r\n");
            
            #line 64 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

        first = false;
    }

            
            #line default
            #line hidden
            this.Write("            writer.Append(\'}\');\r\n        }\r\n\r\n        /// <summary>\r\n        /// " +
                    "Convert object to JSON string\r\n        /// </summary>\r\n        public ");
            
            #line 74 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(@" FromJson(string json)
        {
            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return FromJson(reader);
            }
        }

        /// <summary>
        /// Include this class in a JSON string
        /// </summary>
        public ");
            
            #line 85 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(@" FromJson(JsonReader reader)
        {
            while (reader.Read())
            {
                // Break on EndObject
                if (reader.TokenType == JsonToken.EndObject)
                    break;

                // Only look for properties
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                switch ((string) reader.Value)
                {
");
            
            #line 99 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

    // We start with the easy properties and move on to collections
    foreach (var property in Model.Properties.WhereAttribute(nameof(DataMemberAttribute))
                                  .Where(p => !p.IsCollection))
    {

            
            #line default
            #line hidden
            this.Write("                    case \"");
            
            #line 105 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write("\":\r\n                        reader.Read();\r\n                        ");
            
            #line 107 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 107 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Converter(property)));
            
            #line default
            #line hidden
            this.Write(";\r\n                        break;\r\n\r\n");
            
            #line 110 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

    }

    // And for the fun part collections but first with only one dimension
    foreach (var property in Model.Properties.WhereAttribute(nameof(DataMemberAttribute))
                                  .Where(p => p.IsCollection))
    {
        var varName = property.Name.ToLower();
        var condition = property.ValueType == ValueType.Class
            ? "== JsonToken.StartObject"
            : "!= JsonToken.EndArray";

            
            #line default
            #line hidden
            this.Write("                    case \"");
            
            #line 122 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write("\":\r\n                        reader.Read(); // Read token where array should begin" +
                    "\r\n                        if (reader.TokenType == JsonToken.Null)\r\n             " +
                    "               break;\r\n                        var ");
            
            #line 126 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" = new List<");
            
            #line 126 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.ElementType));
            
            #line default
            #line hidden
            this.Write(">();\r\n                        while (reader.Read() && reader.TokenType ");
            
            #line 127 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(condition));
            
            #line default
            #line hidden
            this.Write(")\r\n                            ");
            
            #line 128 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(".Add(");
            
            #line 128 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Converter(property)));
            
            #line default
            #line hidden
            this.Write(");\r\n                        ");
            
            #line 129 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Dimensions > 1 ? "// TODO: " : string.Empty));
            
            #line default
            #line hidden
            
            #line 129 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 129 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            
            #line 129 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GeneratorTools.ToCollection(property)));
            
            #line default
            #line hidden
            this.Write(";");
            
            #line 129 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Dimensions > 1 ? "<-- Figure this out!" : string.Empty));
            
            #line default
            #line hidden
            this.Write("\r\n                        break;\r\n\r\n");
            
            #line 132 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

    }

            
            #line default
            #line hidden
            this.Write("                }\r\n            }\r\n\r\n            return this;\r\n        }\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 140 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

    // Converter for different property types
    private static string Converter(PropertyModel property)
    {
        var converter = property.ValueType == ValueType.Class
            ? $"new {property.ElementType}().FromJson(reader)"
            : $"Convert.To{property.ValueType}(reader.Value)";
        return converter;
    }

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\Thomas\Documents\Development\CGbR\CGbR\Generator\Serialization\JsonSerializerGenerator.tt"

private global::CGbR.ClassModel _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::CGbR.ClassModel Model
{
    get
    {
        return this._ModelField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ModelValueAcquired = false;
if (this.Session.ContainsKey("Model"))
{
    this._ModelField = ((global::CGbR.ClassModel)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::CGbR.ClassModel)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class JsonSerializerGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
