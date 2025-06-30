import {Link} from "react-router-dom";
import LeftMenu from "../components/LeftMenu";
import ShoppingList from "./ShoppingList.jsx";

function Home() {
    return (
        <div className="home">
            <menu className="left-menu">
                <LeftMenu path="/shopping-list/add-shopping-list" value="Add Shopping List"/>
                <LeftMenu path="/shopping-list/edit-shopping-list" value="Edit Shopping List"/>
                <LeftMenu path="/shopping-list/delete-shopping-list" value="Delete Shopping List"/>
                <LeftMenu path="/shopping-list/view-shopping-list" value="View Shopping List"/>
           </menu>
            <div className="main-view">
                <section className="main-section">
                   <ShoppingList />
                </section>
                </div>
        </div>
    );
}

export default Home;