import { useQuery, useQueryClient } from "@tanstack/react-query"
import supabase from "../supabaseClient";

export const useRiderPoints = (range: number) => {
    const queryClient = useQueryClient();

    const queryFn = async () => {
        let { data, error } = await supabase
            .from("rider_points")
            .select(`
                *, 
                riders (
                    *,
                    nations (
                        *
                    )
                )
            `)
            .order("points", { ascending: false })
            .range(0, range ? range - 1 : 10000)
        return data;
    }

    const query = useQuery({
        queryKey: ["riderPoints", range],
        queryFn: queryFn
    });

    return query;
}