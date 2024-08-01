import Link from "next/link";

export type Rank = number;
export type RiderName = string[];
export type Nation = string[];
export type BirthYear = number;
export type Points = number;

export type Column = Rank | RiderName | Nation | BirthYear | Points;
export type ColumnTypes = "Rank" | "RiderName" | "Nation" | "BirthYear" | "Points";


interface TableProps {
    header: string[],
    data: Column[][],
    columnTypes: ColumnTypes[],
    className?: string | undefined
}

export default function Table({header, data, columnTypes, className}: TableProps){
    return(
        <div className={"table-wrapper " + className}>
            <table>
                <tr>
                    {header?.map((c: string, index: number) => {
                        switch(columnTypes[index]){
                            case "Points":
                                return(
                                    <th key={c + index} className="align-right">
                                        {c}
                                    </th>
                                );
                            case "BirthYear":
                                return(
                                    <th key={c + index} className="d">
                                        {c}
                                    </th>
                                );
                            default: 
                                return(
                                    <th key={c + index}>
                                        {c}
                                    </th>
                                );
                        }

                    })}
                </tr>
                {data?.map((r: any, rowIndex: number) => {
                    return(
                        <tr key={"r" + rowIndex}>
                            {r?.map((c: any, index: number) => {
                                switch(columnTypes[index]){
                                    case "Rank":
                                        return(
                                            <td key={"c" + index}>{c.toLocaleString("de-DE")}</td>
                                        );
                                    case "RiderName":
                                        return(
                                            <td key={"c" + index}>
                                                <Link href="#">
                                                    <span className={"m fi fi-" + c[2]}></span>
                                                    <span className="bold">{c[0]} </span> 
                                                    {c[1]}
                                                </Link>
                                            </td>
                                        );
                                    case "Nation":
                                        return(
                                            <td key={"c" + index}>
                                                <Link href="#">
                                                    <span className={"d fi fi-" + c[0]}></span>
                                                    {c[1]}
                                                </Link>
                                            </td>
                                        );
                                    case "BirthYear":
                                        return(
                                            <td key={"c" + index} className="d">
                                                <Link href="#">
                                                    {c}
                                                </Link>
                                            </td>
                                        );
                                    case "Points":
                                        return(
                                            <td key={"c" + index} className="align-right">{c.toLocaleString("de-DE")}</td>
                                        );
                                    default:
                                        return(
                                            <td key={"c" + index}>{c}</td>
                                        );
                                }

                            })}
                        </tr>
                    )
                })}
            </table>
        </div>
    )
}