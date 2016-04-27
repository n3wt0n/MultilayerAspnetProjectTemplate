TEMPLATE GENERATION
====================
1 - Export the templates form single projects

2 - Extract the files into "Template Files" folder

3 - Run the "Package adaptions" PS script against the "Template Files" folder

4 - Run the "ZipTemplate" PS script (execute it in the Script folder) to Zip the content of the "Template Files" folder and to move it into "TemplatePackages" folder (overwites the zip, if any)

5 - Build the "MVCMultiLayer.Wizard" project in Release configuration

6 - Copy the "MVCMultiLayer.Wizard.dll" file into the "Template Packages" folder

7 - Coy the zip file into "C:\Users\YOUR_USERNAME\Documents\Visual Studio 2015\Templates\ProjectTemplates\Visual C#\"

8 - Register the dlle file in GAC (gacutil /i MVCMultiLayer.TemplateWizard.dll)


TO OBTAIN THE PUBLIC KEY OF THE WIZARD COMPONENT
================================================
1 - Sign the assembly

2 - sn -T MVCMultiLayer.TemplateWizard.dll
