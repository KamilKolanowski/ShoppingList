import {Link} from "react-router-dom";
import LeftMenu from "../../components/LeftMenu.jsx";

function AddShoppingList() {
    return (
        <div className="home">
            <menu className="left-menu">
                <LeftMenu path="/AddShoppingList" value="Add Shopping List"/>
                <LeftMenu path="/EditShoppingList" value="Edit Shopping List"/>
                <LeftMenu path="/DeleteShoppingList" value="Delete Shopping List"/>
                <LeftMenu path="/ViewShoppingList" value="View Shopping List"/>
            </menu>
            <div className="main-view">
                <section className="main-section">
                    test
                </section>
            </div>
        </div>
    );
}

export default AddShoppingList;