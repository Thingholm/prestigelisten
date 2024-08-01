export function GetPlacements(data: object[]){
    let prevObj: any = {};
    let curPlacement: number = 1;
    const formattedData = data
        .sort((a: any, b: any) => b.points - a.points)
        .reduce((acc: any[], obj: any) => {
            if (curPlacement == 1){
                const newObj = {...obj, placement: curPlacement};
                curPlacement++;
                prevObj = newObj;
                return [...acc, newObj];
            }
            const placement: number = obj.points == prevObj.points ? prevObj.placement : curPlacement;
            const newObj = {...obj, placement: placement};
            curPlacement++;
            prevObj = newObj;
            return [...acc, newObj];

        }, []);
    
    return formattedData;
}