using Amazon.Extensions.Configuration.SystemsManager;
using Amazon.SimpleSystemsManagement.Model;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public class AWSParameterProcessor : IParameterProcessor
    {
        public virtual bool IncludeParameter(Parameter parameter, string path) => true;

        public virtual string GetKey(Parameter parameter, string path)
        {
            var res = parameter.Name.Substring(path.Length).TrimStart('/').Replace("--", ConfigurationPath.KeyDelimiter);
            return res;
        }

        public virtual string GetValue(Parameter parameter, string path) => parameter.Value;
    }
}