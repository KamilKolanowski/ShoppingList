import { useState } from "react";
import FetchData from "../api/ApiDataFetch";

function Products() {
    const { products, error } = FetchData(0, "products");
    const [filter, setFilter] = useState("");

    const filteredProducts = products.filter(p =>
        p.productName.toLowerCase().includes(filter.toLowerCase())
    );

    const handleAdd = (product) => {
        console.log("Add to Shopping List:", product);
    };

    return (
        <div className="products">
            <h2>Products</h2>

            <input
                type="text"
                placeholder="Filter products..."
                value={filter}
                onChange={(e) => setFilter(e.target.value)}
                className="product-filter"
            />

            {error ? (
                <p style={{ color: "red" }}>Failed to load products.</p>
            ) : products.length === 0 ? (
                <p>Loading...</p>
            ) : (
                <div className="product-grid">
                    {filteredProducts.map((item, index) => (
                        <div className="product-card" key={index}>
                            <h3>{item.productName}</h3>
                            <p className="price">${item.price}</p>
                            <button
                                className="add-btn"
                                onClick={() => handleAdd(item)}
                            >
                                Add to Shopping List
                            </button>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}

export default Products;
