"use client";

import HeaderLink from "@/components/HeaderLink";
import Table from "@/components/Table";
import { FormatRiderPoints } from "@/data/formatter";
import { GetPlacements } from "@/utils/getPlacements";
import { useRiderPoints } from "@/data/queries/riderPoints";
import Link from "next/link";
import { ImQuotesLeft } from "react-icons/im";

export default function HeroSection(){
    const riderPointsQuery = useRiderPoints(30);

    const riderPoints = riderPointsQuery.data && FormatRiderPoints(GetPlacements(riderPointsQuery.data));
    return(
        <section className="hero">  
            <div className="flex h h-5050">
                <div>
                    <ImQuotesLeft className="quote-icon"/>
                    <p className="quote-text">Cycling isn't a game, it's a sport. Tough, hard and unpitying, and it requires great sacrifices. One plays football, or tennis, or hockey. One doesn't play at cycling.</p>
                    <p className="quote-byline">- Jean De Gribaldy</p>

                    <p>Velkommen til Mathias Jensens og Mathias Fisker Mundbjergs bud på en prestigeliste i landevejscyklingens verden.</p>
                    <p>Vi vil gerne begynde med at slå fast, at pointsystemet er baseret på en subjektiv vurdering, men en gennemdiskuteret og - mener vi selv - kvalificeret en af slagsen.</p>
                    <p>Prestigelistens primære formål er at give mulighed for at sammenligne ryttere over tid. Vi har forsøgt at udfærdige pointgivningen, så hverken de nutidige eller de ældste ryttere favoriseres i for høj grad. Vi har forsøgt at balancere det, så det, at der var mindre konkurrence for 100 år siden, udligner det mindre antal prestigefyldte løb, hvori det var muligt at score point.</p>

                    <div className="btn-container h">
                        <Link href="#" className="btn contained">Udforsk Prestigelisten</Link>
                        <Link href="#" className="btn text">Mere om listen...</Link>
                    </div>
                </div>
                <div>
                    <HeaderLink href="#">All time største ryttere</HeaderLink>
                    { riderPoints && <Table data={riderPoints.data} header={riderPoints.header} columnTypes={riderPoints.columnTypes} className="card"/>}
                </div>
            </div>
        </section>
    )
}