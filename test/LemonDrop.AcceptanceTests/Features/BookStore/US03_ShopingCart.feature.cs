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
namespace LemonDrop.AcceptanceTests.Features.BookStore
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class US03_ShoppingCartFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "US03_ShopingCart.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "US03 - Shopping cart", "\tAs a potential customer\r\n\tI want to collect books in a shopping cart\r\n\tSo that I" +
                    " can order several books at once.", ProgrammingLanguage.CSharp, new string[] {
                        "automated",
                        "BookStore"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "US03 - Shopping cart")))
            {
                global::LemonDrop.AcceptanceTests.Features.BookStore.US03_ShoppingCartFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 8
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "Title",
                        "Price"});
            table1.AddRow(new string[] {
                        "Martin Fowler",
                        "Analysis Patterns",
                        "50.20"});
            table1.AddRow(new string[] {
                        "Eric Evans",
                        "Domain Driven Design",
                        "46.34"});
            table1.AddRow(new string[] {
                        "Ted Pattison",
                        "Inside Windows SharePoint Services",
                        "31.49"});
            table1.AddRow(new string[] {
                        "Gojko Adzic",
                        "Bridging the Communication Gap",
                        "24.75"});
#line 9
 testRunner.Given("the following books", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Books can be placed into shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void BooksCanBePlacedIntoShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Books can be placed into shopping cart", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 18
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.When("I place \'Domain Driven Design\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("my shopping cart should contain 2 types of items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("my shopping cart should contain 1 copy of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("my shopping cart should contain 1 copy of \'Domain Driven Design\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Shopping cart should show total number of items and total price")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void ShoppingCartShouldShowTotalNumberOfItemsAndTotalPrice()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopping cart should show total number of items and total price", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 26
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\', \'Domain Driven Design\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.When("I place \'Analysis Patterns\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("my shopping cart should contain 2 types of items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("my shopping cart should contain 3 items in total", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("my shopping cart should show a total price of 146.74", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The shopping cart should be initially empty")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void TheShoppingCartShouldBeInitiallyEmpty()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The shopping cart should be initially empty", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 34
 testRunner.When("I enter the shop", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("A type of book can be entirely removed from the shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void ATypeOfBookCanBeEntirelyRemovedFromTheShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A type of book can be entirely removed from the shopping cart", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 39
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.When("I delete \'Analysis Patterns\' from the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding the same book to shopping cart again should increase quantity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void AddingTheSameBookToShoppingCartAgainShouldIncreaseQuantity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding the same book to shopping cart again should increase quantity", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 45
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.When("I place \'Analysis Patterns\' into the shopping cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("my shopping cart should contain 1 type of item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("my shopping cart should contain 2 copies of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Quantity of a book can be changed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void QuantityOfABookCanBeChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quantity of a book can be changed", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 52
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.When("I change the quantity of \'Analysis Patterns\' to 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("my shopping cart should contain 1 type of item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.And("my shopping cart should contain 3 copies of \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing quantity of book to 0 should remove book from shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US03 - Shopping cart")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("automated")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BookStore")]
        public virtual void ChangingQuantityOfBookTo0ShouldRemoveBookFromShoppingCart()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing quantity of book to 0 should remove book from shopping cart", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 59
 testRunner.Given("I have a shopping cart with: \'Analysis Patterns\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.When("I change the quantity of \'Analysis Patterns\' to 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("my shopping cart should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
