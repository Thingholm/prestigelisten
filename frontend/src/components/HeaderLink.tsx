import Link from "next/link";
import { IoArrowForwardOutline } from "react-icons/io5";

interface HeaderLinkProps {
    href: string,
    children: Readonly<React.ReactNode>
}

export default function HeaderLink({href, children} : HeaderLinkProps){
    return(
        <Link href={href} className="header-link">{children} <IoArrowForwardOutline /></Link>
    )
}