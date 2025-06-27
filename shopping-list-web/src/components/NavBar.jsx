import { useState } from "react";
import logo from "../assets/logo.svg";
import { Link } from "react-router-dom";

function NavBar() {
    const [menuOpen, setMenuOpen] = useState(false);

    const handleLinkClick = () => setMenuOpen(false);

    return (
        <nav className="navbar">
            <div className="container">
                <Link to="/">
                    <img src={logo} alt="logo" className="logo" />
                </Link>

                <div className={`nav-links ${menuOpen ? "open" : ""}`}>
                    <div className="navbar-header">
                        <Link to="/" onClick={handleLinkClick}>Home</Link>
                    </div>
                    <div className="navbar-header">
                        <Link to="/products" onClick={handleLinkClick}>Products</Link>
                    </div>
                    <div className="navbar-header">
                        <Link to="/shopping-list" onClick={handleLinkClick}>Shopping List</Link>
                    </div>
                </div>

                <div className="hamburger" onClick={() => setMenuOpen(!menuOpen)}>
                    ☰
                </div>
            </div>
        </nav>
    );
}

export default NavBar;

