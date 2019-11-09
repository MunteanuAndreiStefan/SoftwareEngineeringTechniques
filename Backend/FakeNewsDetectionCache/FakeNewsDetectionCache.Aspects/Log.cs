using AspectInjector.Broker;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace FakeNewsDetectionCache.Aspects
{
    [Aspect(Scope.Global)]
    [Injection(typeof(Log))]
    public class Log: Attribute
    {

        protected ILogger logger;

        public Log()
        {
            logger = new LoggerFactory().AddFile("Logs/aspects-{Date}.txt").CreateLogger(typeof(Log));
        }

        [Advice(Kind.Around, Targets = Target.Method)]
        public object HandleMethod(
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] arguments,
            [Argument(Source.Target)] Func<object[], object> method)
        {
            string args = "";
            foreach (var arg in arguments)
                args = args + arg.ToString();
            logger.LogInformation($"Executing method {name} with the arguments {args}");
            //Console.WriteLine($"Executing method {name}");

            var sw = Stopwatch.StartNew();

            var result = method(arguments);

            sw.Stop();

            //Console.WriteLine($"Executed method {name} in {sw.ElapsedMilliseconds} ms");
            logger.LogInformation($"Executed method {name} in {sw.ElapsedMilliseconds} ms with the result {result}");
            return result;
        }
    }
}
