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
                <table className="shopping-list">
                    <tr className="shopping-table-header">
                        <th className="header">Product Id</th>
                        <th className="header">Quantity</th>
                        <th className="header">Weight (kg)</th>
                        <th className="header">Total ($)</th>
                        <th className="header">Picked Up</th>
                        <th className="header">Action</th>
                    </tr>
                    {items.map(item => (
                        <tr key={item.id} className="body-items">
                            <td className="body-item">{item.productId}</td>
                            <td className="body-item">{item.quantity}</td>
                            <td className="body-item">{item.weight.toFixed(2)}</td>
                            <td className="body-item">${item.total.toFixed(2)}</td>
                            <td className="body-item">{item.isPickedUp || pickedUpIds.includes(item.id) ? "✔️" : "❌"}</td>
                            <td className="body-item">
                                <button
                                    className="pick-btn"
                                    onClick={() => togglePickedUp(item.id)}
                                >
                                    Mark as {pickedUpIds.includes(item.id) || item.isPickedUp ? "Not Picked" : "Picked"}
                                </button>
                            </td>
                        </tr>
                    ))}
                </table>
            )}
        </div>
    );
}

export default ShoppingList;
