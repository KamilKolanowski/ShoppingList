import './css/App.css'
import NavBar from './components/NavBar'
import Footer from './components/Footer'
import Home from './pages/Home'
import Products from './pages/Products'
import ShoppingList from './pages/ShoppingList'
import {BrowserRouter, Routes, Route } from "react-router-dom";
import AddShoppingList from "./pages/shopping-list/AddShoppingList.jsx";

function App() {
    return (
        <BrowserRouter>
            <div className="App">
                <NavBar />
                <main className="content">
                    <Routes>
                        <Route index element={<Home />} />
                        <Route path="/products" element={<Products />} />
                        <Route path="/shopping-list" element={<ShoppingList />} />
                        <Route path="/shopping-list/add-shopping-list" element={<AddShoppingList />} />
                    </Routes>
                </main>
                {/*<Footer />*/}
            </div>
        </BrowserRouter>
    )
}

export default App