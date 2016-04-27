# MultilayerAspnetProjectTemplate
A multilayer Asp.net MVC web app project template for Visual Studio 2015

It has all the components you need to start a structured, multi-layer Web Application based on Asp.Net MVC and .Net Framework v4.6.1 (with Entity Framework):

* Presentation Layer
  * Some useful Http and Ajax Helpers
  * Some basic model binders
  * Some useful Extension Methods
* Business Layer
  * Business Entities
  * Some useful Extension Methods
  * Some useful business objects Managers
  * Example of Business Logic
  * Example of "DAL Entity" to/from "Business Entity" Mapper
* Data Access Layer
  * DAL (DB) Entities
  * Generic and Typed Repositories
  * EF Context
  * Migrations
* Log Layer
  * Based on NLog
  * Extendible
* Simple unit test projects
  * Presentation layer tests
  * Business layer tests
  * Fake entities and helpers


# How to use the template

It is very simple!
+ Grab the **MVCMultiLayer.Template.zip** and the **MVCMultiLayer.TemplateWizard.dll** files from the *"TemplatePackages"* folder
+ Copy the **zip** file to the *"C:\Users\YOUR_USERNAME\Documents\Visual Studio 2015\Templates\ProjectTemplates\Visual C#\"* folder
+ Register the **dll** library into the GAC with the command `gacutil /i MVCMultiLayer.TemplateWizard.dll`

Read the "INFO.md" file to have more information on template generation and usage.
