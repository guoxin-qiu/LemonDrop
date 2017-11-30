﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LemonDrop.AcceptanceTests.Features.Account
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class US01_UserRegistrationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "US01_UserRegistration.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "US01 - User Registration", "\tIn order to use the website\r\n\tAs a potential user\r\n\tI want to register as a form" +
                    "al user", ProgrammingLanguage.CSharp, new string[] {
                        "Account",
                        "automated",
                        "web"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "US01 - User Registration")))
            {
                global::LemonDrop.AcceptanceTests.Features.Account.US01_UserRegistrationFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        public virtual void RegisterSuccessfully()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register successfully", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "FirstName",
                        "LastName",
                        "Gender",
                        "Password",
                        "ConfirmPassword"});
            table1.AddRow(new string[] {
                        "denis@lemon-drop.net",
                        "Denis",
                        "Qiu",
                        "Male",
                        "p@55w0rd!",
                        "p@55w0rd!"});
#line 10
 testRunner.When("I submit the following information on Register page", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Value"});
            table2.AddRow(new string[] {
                        "Hello Qiu Denis, welcome to join us!"});
            table2.AddRow(new string[] {
                        "Your account is denis@lemon-drop.net"});
#line 13
 testRunner.Then("I should see the following information on the Welcome page", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register successfully again")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        public virtual void RegisterSuccessfullyAgain()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register successfully again", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "FirstName",
                        "LastName",
                        "Gender",
                        "Password",
                        "ConfirmPassword"});
            table3.AddRow(new string[] {
                        "test01@lemon-drop.net",
                        "Tester01",
                        "LemonDrop",
                        "Female",
                        "p@55w0rd!",
                        "p@55w0rd!"});
#line 19
 testRunner.When("I submit the following information on Register page", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Value"});
            table4.AddRow(new string[] {
                        "Hello LemonDrop Tester01, welcome to join us!"});
            table4.AddRow(new string[] {
                        "Your account is test01@lemon-drop.net"});
#line 22
 testRunner.Then("I should see the following information on the Welcome page", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void RegisterFailed(string email, string firstName, string lastName, string gender, string password, string confirmPassword, string errorMessage, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register failed", exampleTags);
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "FirstName",
                        "LastName",
                        "Gender",
                        "Password",
                        "ConfirmPassword"});
            table5.AddRow(new string[] {
                        string.Format("{0}", email),
                        string.Format("{0}", firstName),
                        string.Format("{0}", lastName),
                        string.Format("{0}", gender),
                        string.Format("{0}", password),
                        string.Format("{0}", confirmPassword)});
#line 28
 testRunner.When("I submit the following information on Register page", ((string)(null)), table5, "When ");
#line 31
 testRunner.Then(string.Format("I should see error messages \'{0}\' on the Register page", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "Denis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "Qiu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'Email is required\'")]
        public virtual void RegisterFailed_Variant0()
        {
#line 27
this.RegisterFailed("", "Denis", "Qiu", "Male", "p@55w0rd!", "p@55w0rd!", "\'Email is required\'", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "invalid@")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "Denis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "Qiu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'Email is not valid\'")]
        public virtual void RegisterFailed_Variant1()
        {
#line 27
this.RegisterFailed("invalid@", "Denis", "Qiu", "Male", "p@55w0rd!", "p@55w0rd!", "\'Email is not valid\'", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "denis@lemon-drop.net")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'FirstName is required\',\'LastName is required\'")]
        public virtual void RegisterFailed_Variant2()
        {
#line 27
this.RegisterFailed("denis@lemon-drop.net", "", "", "Male", "p@55w0rd!", "p@55w0rd!", "\'FirstName is required\',\'LastName is required\'", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "denis@lemon-drop.net")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "Denis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'LastName is required\'")]
        public virtual void RegisterFailed_Variant3()
        {
#line 27
this.RegisterFailed("denis@lemon-drop.net", "Denis", "", "Male", "p@55w0rd!", "p@55w0rd!", "\'LastName is required\'", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "denis@lemon-drop.net")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "Denis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "Qiu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'Password must be longer than 5 characters\'")]
        public virtual void RegisterFailed_Variant4()
        {
#line 27
this.RegisterFailed("denis@lemon-drop.net", "Denis", "Qiu", "Male", "p@55w", "p@55w", "\'Password must be longer than 5 characters\'", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Register failed: Variant 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US01 - User Registration")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Account")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("web")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Email", "denis@lemon-drop.net")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FirstName", "Denis")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:LastName", "Qiu")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "p@55w0rd!")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ConfirmPassword", "p@55w0rd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ErrorMessage", "\'Password not match\'")]
        public virtual void RegisterFailed_Variant5()
        {
#line 27
this.RegisterFailed("denis@lemon-drop.net", "Denis", "Qiu", "Male", "p@55w0rd!", "p@55w0rd", "\'Password not match\'", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
