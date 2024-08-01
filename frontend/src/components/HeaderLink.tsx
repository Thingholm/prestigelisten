import Link from "next/link";

interface HeaderLinkProps {
    href: string,
    children: Readonly<React.ReactNode>
}

export default function HeaderLink({href, children} : HeaderLinkProps){
    return(
        <Link href={href}>{children}</Link>
    )
}