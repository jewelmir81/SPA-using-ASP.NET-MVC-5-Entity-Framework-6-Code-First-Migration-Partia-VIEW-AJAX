<p>Only the Index view is called as view from Index action of categories controller. All other views are called as partial view from both controllers (Categories and Items) and Index view. Only Categories has Index view. All forms are created by using Ajax.BeginForm. Index.cshtml of Categories is the default view. You can invoke all the actions of the both controllers (Categories and Items)</p>
<p>
    Workflow thorugh Categories Controller:
    <ol type="1" start="1">
        <li>When details button of the Index view is cilcked, it calls the javascript getDetails method, which invokes the GetCategoryWiseItems action of Categories Controller that returns CategoryWiseItems partial view and load it to itemsDiv div.</li>
        <li>When Create New button of the Index view is cilcked, it invokes a bootstrap modal named categoryModal. This modal's content is rendered by the Html.RenderPartial which takes an empty Category object and invokes the Create view of Categories as partial view that is initialized by the Category object passed by the Html.RenderPartial. You can add one Categoty nad multiple Items for this Category from this single partial Create view modal. Click the aAdd more product button to add more Item.</li>
        <li>When Edit button of the Index view is cilcked, it invokes a bootstrap modal named editCategoryModal and calls the javascript editCategory method. The editCategory method invokes the Edit action of the Categories Controller using helper method Url.Action. The Edit action of the Categories Controller returns the Edit view as partial view and load it to the editCategoryModalContent div of the editCategoryModal modal. The Edit view loads with all the Items of this Category. This Category and it's all Items will be edited from this partial view.</li>
        <li>When Delete button of the Index view is cilcked, it invokes a bootstrap modal named deleteCategoryModal and calls the javascript deleteCategory method. The deleteCategory method invokes the Delete action of the Categories Controller using helper method Url.Action. The Delete action of the Categories Controller returns the Delete view as partial view and load it to the deleteCategoryModalContent div of the deleteCategoryModal modal. If you delete this Category all the Items of the Category will also be deleted.</li>
    </ol>
</p>
<p>
    Workflow thorugh Items Controller:
    <ol type="1" start="1">
        <li>When Create New button of the CategoryWiseItems partial view is cilcked, it invokes a bootstrap modal named itemModal and calls the javascript loadItem method. The loadItem method invokes the Create action of the Items Controller using helper method Url.Action. The Create action of the Items Controller returns the Create view as partial view and load it to the itemModalContent div of the itemModal modal.</li>
        <li>When Edit button of the CategoryWiseItems partial view is cilcked, it invokes a bootstrap modal named editItemModal and calls the javascript editItem method. The editItem method invokes the Edit action of the Items Controller using helper method Url.Action. The Edit action of the Items Controller returns the Edit view as partial view and load it to the editItemModalContent div of the editItemModal modal.</li>
        <li>When Delete button of the CategoryWiseItems partial view is cilcked, it invokes a bootstrap modal named deleteItemModal and calls the javascript deleteItem method. The deleteItem method invokes the Delete action of the Items Controller using helper method Url.Action. The Delete action of the Items Controller returns the Delete view as partial view and load it to the deletItemModalContent div of the deleteItemModal modal.</li>
    </ol>
</p>
<p>
<h3><a href="http://jewel.features.site" target="_blank">SYED ZAHIDUL HASSAN</a></h3>
<address>
    77/C, Jonaki Road<br />
    Ahammed Nagar, Mirpur<br />
    Dhaka-1216, Dhaka, Bangladesh<br />
    <abbr title="Phone">P:</abbr>
    +88(018) 17 015 015
</address>
<address>
    <strong>LIVE:</strong>   <a href="mailto:jewelmir@live.com">jewelmir@live.com</a><br />
    <strong>GMAIL:</strong> <a href="mailto:jewelmir81@gmail.com">jewelmir81@gmail.com</a><br />
    <strong>Website:</strong> <a href="http://features.site/" target="_blank">features.site</a>
</address></p>