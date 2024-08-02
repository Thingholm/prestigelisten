import { useQuery, useQueryClient } from "@tanstack/react-query"
import supabase from "../supabaseClient";

export const useResults = (range: number) => {
    const queryClient = useQueryClient();

    const queryFn = async () => {
        let { data, error } = await supabase
            .from("results")
            .select(`
                *, 
                riders (
                    *,
                    nations (
                        *
                    )
                ),
                race_dates (
                    *
                ),
                races (
                    *,
                    nations (
                        *
                    )
                )
            `)
            .gt("race_date_id", 0)
            .order("race_dates(date)", {ascending: false})
            .range(0, range ? range - 1 : 10000)
        return data;
    }

    const query = useQuery({
        queryKey: ["results", range],
        queryFn: queryFn
    });

    return query;
}