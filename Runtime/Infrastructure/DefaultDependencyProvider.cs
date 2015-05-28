﻿using BoDi;
using TechTalk.SpecFlow.BindingSkeletons;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Discovery;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.ErrorHandling;
using TechTalk.SpecFlow.Tracing;

namespace TechTalk.SpecFlow.Infrastructure
{
    public partial class DefaultDependencyProvider : IDefaultDependencyProvider
    {
        partial void RegisterUnitTestProviders(ObjectContainer container);

        public virtual void RegisterDefaults(ObjectContainer container)
        {
            container.RegisterTypeAs<DefaultRuntimeConfigurationProvider, IRuntimeConfigurationProvider>();

            container.RegisterTypeAs<TestRunnerManager, ITestRunnerManager>();

            container.RegisterTypeAs<StepFormatter, IStepFormatter>();
            container.RegisterTypeAs<TestTracer, ITestTracer>();

            container.RegisterTypeAs<DefaultListener, ITraceListener>();
            container.RegisterTypeAs<TraceListenerQueue, TraceListenerQueue>(); 

            container.RegisterTypeAs<ErrorProvider, IErrorProvider>();
            container.RegisterTypeAs<RuntimeBindingSourceProcessor, IRuntimeBindingSourceProcessor>();
            container.RegisterTypeAs<RuntimeBindingRegistryBuilder, IRuntimeBindingRegistryBuilder>();
            container.RegisterTypeAs<BindingRegistry, IBindingRegistry>();
            container.RegisterTypeAs<BindingFactory, IBindingFactory>();
            container.RegisterTypeAs<StepDefinitionRegexCalculator, IStepDefinitionRegexCalculator>();
            container.RegisterTypeAs<BindingInvoker, IBindingInvoker>();

            container.RegisterTypeAs<StepDefinitionSkeletonProvider, IStepDefinitionSkeletonProvider>();
            container.RegisterTypeAs<DefaultSkeletonTemplateProvider, ISkeletonTemplateProvider>();
            container.RegisterTypeAs<StepTextAnalyzer, IStepTextAnalyzer>();

            container.RegisterTypeAs<RuntimePluginLoader, IRuntimePluginLoader>();

            container.RegisterTypeAs<BindingAssemblyLoader, IBindingAssemblyLoader>();

            RegisterUnitTestProviders(container);
        }

        public void RegisterTestRunnerDefaults(ObjectContainer testRunnerContainer)
        {
            testRunnerContainer.RegisterTypeAs<TestRunner, ITestRunner>();
            testRunnerContainer.RegisterTypeAs<ContextManager, IContextManager>();
            testRunnerContainer.RegisterTypeAs<TestExecutionEngine, ITestExecutionEngine>();

            // needs to invoke methods so requires the context manager
            testRunnerContainer.RegisterTypeAs<StepArgumentTypeConverter, IStepArgumentTypeConverter>();
            testRunnerContainer.RegisterTypeAs<StepDefinitionMatchService, IStepDefinitionMatchService>();

            testRunnerContainer.RegisterTypeAs<AsyncTraceListener, ITraceListener>();
            testRunnerContainer.RegisterTypeAs<AsyncTestTracer, ITestTracer>(); //TODO[thread-safety]: fix bodi error to avoid this
        }

        class AsyncTestTracer : TestTracer
        {
            public AsyncTestTracer(ITraceListener traceListener, IStepFormatter stepFormatter, IStepDefinitionSkeletonProvider stepDefinitionSkeletonProvider, RuntimeConfiguration runtimeConfiguration)
                : base(traceListener, stepFormatter, stepDefinitionSkeletonProvider, runtimeConfiguration)
            {
            }
        }
    }
}