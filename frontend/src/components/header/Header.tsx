import Link from "next/link";

export default function Header(){
    return(
        <header>
            <h1><Link href="/">Prestigelisten</Link></h1>
            <nav>
                <ul>
                    <li>
                        <Link href="#">Om Prestigelisten</Link>
                    </li>
                    <li>
                        <Link href="#">Pointsystem</Link>
                    </li>
                    <li>
                        <p>Ranglister</p>
                    </li>
                    <li>
                        <p>Mere</p>
                    </li>
                </ul>
            </nav>
            <div>
                <Link href="#" className="btn contained primary">Se listen</Link>
            </div>
        </header>  
    );
}