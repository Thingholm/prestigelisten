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
    columnTypes: ColumnTypes[]
}

export default function Table({header, data, columnTypes}: TableProps){
    return(
        <table>
            <tr>
                {header?.map((c: string, index: number) => {
                    return(
                        <th key={c + index}>
                            {c}
                        </th>
                    )
                })}
            </tr>
            {data?.map((r: any, rowIndex: number) => {
                return(
                    <tr key={"r" + rowIndex}>
                        {r?.map((c: any, index: number) => {
                            switch(columnTypes[index]){
                                case "RiderName":
                                    return(
                                        <td key={"c" + index}><span className={"m fi fi-" + c[2]}></span><span className="bold">{c[0]}</span> {c[1]}</td>
                                    );
                                case "Nation":
                                    return(
                                        <td key={"c" + index}><span className={"d fi fi-" + c[0]}></span>{c[1]}</td>
                                    );
                                case "BirthYear":
                                    return(
                                        <td key={"c" + index} className="d">{c}</td>
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
    )
}