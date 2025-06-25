function Home() {
    return (
        <div className="home">
            <menu className="left-menu">
                <div className="menu">Add Shopping List</div>
                <div className="menu">Edit Shopping List</div>
                <div className="menu">Delete Shopping List</div>
            </menu>
            <div className="main-view">
                <h2>Shopping List</h2>
                <table>
                    <tr>
                        <th>Item</th>
                        <th>Quantity</th>
                    </tr>
                    <tr>
                        <td>Milk</td>
                        <td>2 liters</td>
                    </tr>
                    <tr>
                        <td>Bread</td>
                        <td>1 loaf</td>
                    </tr>
                    <tr>
                        <td>Eggs</td>
                        <td>12</td>
                    </tr>
                    <tr>
                        <td>Apples</td>
                        <td>6</td>
                    </tr>
                    <tr>
                        <td>Chicken</td>
                        <td>1 kg</td>
                    </tr>
                </table>
            </div>
        </div>
    );
}

export default Home;