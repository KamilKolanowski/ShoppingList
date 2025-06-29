import LeftMenu from "../../components/LeftMenu.jsx";

function EditShoppingList() {
    return (
        <>
            <div className="home">
                <nav className="left-menu">
                    <LeftMenu path="/shopping-list/add-shopping-list" value="Add Shopping List"/>
                    <LeftMenu path="/shopping-list/edit-shopping-list" value="Edit Shopping List"/>
                    <LeftMenu path="/shopping-list/delete-shopping-list" value="Delete Shopping List"/>
                    <LeftMenu path="/shopping-list/view-shopping-list" value="View Shopping List"/>
                </nav>
                <div className="main-view">
                    <section className="main-section">
                        Edit Shopping List
                    </section>
                </div>
            </div>
        </>
    )
}

export default EditShoppingList;