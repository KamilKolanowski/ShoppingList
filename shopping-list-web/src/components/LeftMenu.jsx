import {Link} from "react-router-dom";

function LeftMenu({ path, value }) {
    return (
        <>
            <div className="menu">
                <Link to={path}>
                    {value}
                </Link>
            </div>
        </>
    )
}

export default LeftMenu;
