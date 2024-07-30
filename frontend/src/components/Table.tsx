import "flag-icons/css/flag-icons.min.css";

type ColumnSpecification = "Rank" | "RiderName" | "Nation" | "Points";

interface TableProps {
    header: string[],
    data: Array<Array<any>>,
    columnSpecifications: ColumnSpecification[]
}

export default function Table({header, data, columnSpecifications}: TableProps){
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
                            switch(columnSpecifications[index]){
                                case "RiderName":
                                    return(
                                        <td key={"c" + index}><span className="bold">{c[0]}</span> {c[1]}</td>
                                    );
                                case "Nation":
                                    return(
                                        <td key={"c" + index}><span className={"fi fi-" + c[0]}></span>{c[1]}</td>
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