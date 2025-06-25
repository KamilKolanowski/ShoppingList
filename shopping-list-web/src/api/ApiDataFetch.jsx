import {useState, useEffect} from "react";

function FetchData(reload = 0, endpoint) {
    const [products, setProducts] = useState([]);
    const [error, setError] = useState(false);

    useEffect(() => {
        async function fetchCats() {
            try {
                setError(false);
                const resp = await fetch(`http://localhost:5118/api/shopping-list/${endpoint}`);
                if (!resp.ok) throw new Error('Failed to fetch');
                const data = await resp.json();
                setProducts(data);
            } catch {
                setProducts([]);
                setError(true);
            }
        }
        fetchCats();
    }, [reload]);

    return { products, error };
}

export default FetchData;