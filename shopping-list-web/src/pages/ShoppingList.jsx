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
                <table className="shopping-table">
                    <thead>
                    <tr>
                        <th>Product ID</th>
                        <th>Quantity</th>
                        <th>Weight (kg)</th>
                        <th>Total ($)</th>
                        <th>Picked Up</th>
                        <th>Action</th>
                    </tr>
                    </thead>
                    <tbody>
                    {items.map(item => (
                        <tr key={item.id}>
                            <td>{item.productId}</td>
                            <td>{item.quantity}</td>
                            <td>{item.weight.toFixed(2)}</td>
                            <td>${item.total.toFixed(2)}</td>
                            <td>{item.isPickedUp || pickedUpIds.includes(item.id) ? "✔️" : "❌"}</td>
                            <td>
                                <button
                                    className="pick-btn"
                                    onClick={() => togglePickedUp(item.id)}
                                >
                                    Mark as {pickedUpIds.includes(item.id) || item.isPickedUp ? "Not Picked" : "Picked"}
                                </button>
                            </td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}

export default ShoppingList;
