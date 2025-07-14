import { useState } from "react";
import GetProducts from "../api/ApiDataFetch";

function ShoppingList() {
    const { products: items, error } = GetProducts(0, "items");
    const [pickedUpIds, setPickedUpIds] = useState([]);

    const togglePickedUp = (id) => {
        setPickedUpIds((prev) =>
            prev.includes(id) ? prev.filter(i => i !== id) : [...prev, id]
        );
    };

    return (
        <div className="shopping-list">
            <h2>Shopping List</h2>

            {error ? (
                <p style={{ color: "red" }}>Failed to load items.</p>
            ) : items.length === 0 ? (
                <p>Loading...</p>
            ) : (
                <div className="shopping-table">
                    <div className="shopping-table-header">
                        <div className="header">Product Name</div>
                        <div className="header">Quantity</div>
                        <div className="header">Weight (kg)</div>
                        <div className="header">Total ($)</div>
                        {/*<div className="header">Picked Up</div>*/}
                        <div className="header">Action</div>
                    </div>
                    <div className="shopping-table-body">
                    {items.map(item => (
                        <div key={item.id} className="body-items">
                            <div className="body-item">Test Product Name</div>
                            <div className="body-item">{item.quantity}</div>
                            <div className="body-item">{item.weight.toFixed(2)}</div>
                            <div className="body-item">${item.total.toFixed(2)}</div>
                            {/*<div className="body-item">{item.isPickedUp || pickedUpIds.includes(item.id) ? "" : ""}</div>*/}
                            <div className="body-item">
                                <button
                                    className="pick-btn"
                                    onClick={() => togglePickedUp(item.id)}
                                >
                                    {pickedUpIds.includes(item.id) || item.isPickedUp ? "️Picked" : "Not Picked"}
                                </button>
                            </div>
                        </div>
                    ))}
                    </div>
                </div>
            )}
        </div>
    );
}

export default ShoppingList;
