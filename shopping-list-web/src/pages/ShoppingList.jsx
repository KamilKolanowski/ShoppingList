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
                    <thead>
                    <tr>
                        <th>Product Id</th>
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
                            <td data-label="Product Id">{item.productId}</td>
                            <td data-label="Quantity">{item.quantity}</td>
                            <td data-label="Weight (kg)">{item.weight.toFixed(2)}</td>
                            <td data-label="Total ($)">${item.total.toFixed(2)}</td>
                            <td data-label="Picked Up">{item.isPickedUp || pickedUpIds.includes(item.id) ? "✔️" : "❌"}</td>
                            <td data-label="Action">
                                <button className="pick-btn" onClick={() => togglePickedUp(item.id)}>
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
