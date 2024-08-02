import { BirthYear, Column, ColumnTypes, Nation, Points, Rank, RiderName } from "@/components/Table";

export function FormatRiderPoints(data: object[]){
    const formattedData: Column[][] = data.reduce((acc: Column[][], obj: any) => {
        const placement: Rank = obj.placement;
        const name: RiderName = [obj.riders.last_name, obj.riders.first_name, obj.riders.nations.code];
        const nation: Nation = [obj.riders.nations.code, obj.riders.nations.name];
        const birthYear: BirthYear = obj.riders.birth_year;
        const points: Points = obj.points;

        return [...acc, [placement, name, nation, birthYear, points]];
    }, [])

    const header: string[] = ["Nr.", "Rytter", "Nation", "Årgang", "Point"];
    const columnTypes: ColumnTypes[] = ["Rank", "RiderName", "Nation", "BirthYear", "Points"];

    return {
        data: formattedData,
        header: header,
        columnTypes: columnTypes
    }
}